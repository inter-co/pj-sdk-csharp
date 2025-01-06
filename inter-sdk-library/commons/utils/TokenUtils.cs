namespace inter_sdk_library;

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

public class TokenUtils {
    private static Dictionary<string, GetTokenResponse> map = new Dictionary<string, GetTokenResponse>();
    private const int SECONDS_TO_RENEW = 60;

    public static string GetToken(Config config, string scopes, X509Certificate2Collection certificates) {
        GetTokenResponse tokenInfo;
        map.TryGetValue(scopes, out tokenInfo);
        bool isTokenValid = ValidateToken(tokenInfo);

        if (!isTokenValid) {
            tokenInfo = makeTokenRequest(config, scopes, certificates);
            map[scopes] = tokenInfo;
        }
        
        return tokenInfo.AccessToken;
    }

    private static bool ValidateToken(GetTokenResponse getTokenResponse) {
        if (getTokenResponse == null) {
            return false;
        }

        long? expirationDate = getTokenResponse.CreatedAt + getTokenResponse.ExpiresIn;
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return (now + SECONDS_TO_RENEW) <= expirationDate;
    }

    public static GetTokenResponse makeTokenRequest(Config config, string scope, X509Certificate2Collection certificates) {
        string url = UrlUtils.BuildUrl(config, Constants.URL_TOKEN);

        InterSdk.LogInfo("POST {0}", url);
        HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
        req.ClientCertificates = certificates;
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";

        string postData = string.Format("client_id={0}&client_secret={1}&grant_type=client_credentials&scope={2}", 
            config.ClientId, config.ClientSecret, scope);
        byte[] postBytes = Encoding.UTF8.GetBytes(postData);
        req.ContentLength = postBytes.Length;

        Stream postStream = req.GetRequestStream();
        postStream.Write(postBytes, 0, postBytes.Length);
        postStream.Flush();
        postStream.Close();    
    
        HttpWebResponse resp;
        try {
            resp = (HttpWebResponse) req.GetResponse();
        } catch (WebException e) {
            resp = (HttpWebResponse) e.Response;
            if (resp.StatusCode == HttpStatusCode.TooManyRequests && config.RateLimitControl) {
                Thread.Sleep(60000);
                return makeTokenRequest(config, scope, certificates);
            }
        }

        GetTokenResponse token = null;
        InterSdk.LogInfo("HTTPSTATUS {0}", resp.StatusCode.ToString());
        using (System.IO.Stream s = resp.GetResponseStream()) {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(s)) {
                string jsonResponse = sr.ReadToEnd();
                int code = (int) resp.StatusCode;
                if (config.Debug && code >= 400) {
                    InterSdk.LogInfo("RESPONSE {0}", jsonResponse);
                }
                token = JsonSerializer.Deserialize<GetTokenResponse>(jsonResponse)!;
            }
        }
        token.CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return token;
    }
}
