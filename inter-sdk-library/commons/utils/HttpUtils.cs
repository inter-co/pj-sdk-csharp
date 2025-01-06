namespace inter_sdk_library;

using System.IO;
using System.Text;
using System.Net;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public class HttpUtils {
    public static string LastUrl;
    public static string LastRequest;

    public static string CallVerb(Config config, string url, string scope, string message, string body, string verb) {
        LastUrl = url;
        LastRequest = body;
        X509Certificate2Collection certificates = new X509Certificate2Collection();
        certificates.Import(config.Certificate, config.Password, X509KeyStorageFlags.PersistKeySet);
        string token = TokenUtils.GetToken(config, scope, certificates);

        InterSdk.LogInfo("{0} {1}", verb, url);
        HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
        req.ClientCertificates = certificates;
        req.Method = verb;
        req.Headers.Add("Authorization", "Bearer " + token);
        if (config.Account != null && !config.Account.Equals("")) {
            req.Headers.Add("x-conta-corrente", config.Account);
        }
        req.Headers.Add("x-inter-sdk", "csharp");
        req.Headers.Add("x-inter-sdk-version", "1.0.0");

        if (body != null && !body.Equals("")) {
            if (config.Debug) {
                InterSdk.LogInfo("REQUEST {0}", body);
            }
            req.ContentType = "application/json";
            req.ContentLength = body.Length;
            StreamWriter streamWriter = new StreamWriter(req.GetRequestStream());
            streamWriter.Write(body);
            streamWriter.Close();
        }

        string jsonResponse = "";
        HttpWebResponse resp;
        string err = null;
        try {
            resp = (HttpWebResponse) req.GetResponse();
        } catch (WebException e) {
            resp = (HttpWebResponse) e.Response;
            if (resp.StatusCode == HttpStatusCode.TooManyRequests && config.RateLimitControl) {
                Thread.Sleep(60000);
                return CallVerb(config, url, scope, message, body, verb);
            }
            err = e.Message;
        }

        using (System.IO.Stream s = resp.GetResponseStream()) {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(s)) {
                jsonResponse = sr.ReadToEnd();
                if (config.Debug) {
                    InterSdk.LogInfo("RESPONSE {0}", jsonResponse);
                }
            }
        }
        if (err != null) {
            Error error = buildError(err, jsonResponse);
            throw new SdkException(err, error);
        }
        return jsonResponse;
    }

    public static Error buildError(string err, string jsonResponse) {
        if (!string.IsNullOrEmpty(jsonResponse)) {
            return JsonSerializer.Deserialize<Error>(jsonResponse)!;
        } else {
            return new Error{
                Title = "Error",
                Detail = err,
            };
        }
    }
    public static string CallGet(Config config, string url, string scope, string message) {
        return CallVerb(config, url, scope, message, null, "GET");
    }

    public static string CallPost(Config config, string url, string scope, string message, string body) {
        return CallVerb(config, url, scope, message, body, "POST");
    }

    public static string CallPut(Config config, string url, string scope, string message, string body) {
        return CallVerb(config, url, scope, message, body, "PUT");
    }

    public static string CallPatch(Config config, string url, string scope, string message, string body) {
        return CallVerb(config, url, scope, message, body, "PATCH");
    }

    public static string CallDelete(Config config, string url, string scope, string message) {
        return CallVerb(config, url, scope, message, null, "DELETE");
    }

}
