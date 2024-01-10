using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Sdk {
    public class HttpUtils {
        public static string LastUrl;
        public static string LastRequest;

        public static string CallVerb(Config config, string url, string scope, string message, string body, string verb) {
            LastUrl = url;
            LastRequest = body;
            X509Certificate2Collection certificates = new X509Certificate2Collection();
            certificates.Import(config.Certificado, config.Senha, X509KeyStorageFlags.PersistKeySet);
            Token token = TokenUtils.GetToken(config, scope, certificates);

            InterSdk.LogInfo("{0} {1}", verb, url);
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
            req.ClientCertificates = certificates;
            req.Method = verb;
            req.Headers.Add("Authorization", "Bearer " + token.access_token);
            if (config.ContaCorrente != null && !config.ContaCorrente.Equals("")) {
                req.Headers.Add("x-conta-corrente", config.ContaCorrente);
            }
            req.Headers.Add("x-inter-sdk", "csharp");
            req.Headers.Add("x-inter-sdk-version", "1.0.0");

            if (body != null && !body.Equals("")) {
                if (config.Debug) {
                    InterSdk.LogInfo("REQUEST {0}", body);
                }
                req.ContentType = "application/json";
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                req.ContentLength = bodyBytes.Length;
                using (Stream stream = req.GetRequestStream()) {
                    stream.Write(bodyBytes, 0, bodyBytes.Length);
                }
            }

            string jsonResponse = "";
            HttpWebResponse resp;
            string err = null;
            try {
                resp = (HttpWebResponse) req.GetResponse();
            } catch (WebException e) {
                resp = (HttpWebResponse) e.Response;
                if (resp.StatusCode == HttpStatusCode.TooManyRequests && config.ControleRateLimit) {
                    Thread.Sleep(60000);
                    return CallVerb(config, url, scope, message, body, verb);
                }
                err = e.Message;
            }
            InterSdk.LogInfo("HTTPSTATUS {0}", resp.StatusCode.ToString());
            using (System.IO.Stream s = resp.GetResponseStream()) {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s)) {
                    jsonResponse = sr.ReadToEnd();
                    if (config.Debug) {
                        InterSdk.LogInfo("RESPONSE {0}", jsonResponse);
                    }
                }
            }
            if (err != null) {
                throw new SdkException(err, jsonResponse);
            }
            return jsonResponse;
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

        public static Token ObterToken(Config config, string scope, X509Certificate2Collection certificates) {
            string url = Constants.URL_TOKEN.Replace("AMBIENTE", config.Ambiente);

            InterSdk.LogInfo("POST {0}", url);
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
            req.ClientCertificates = certificates;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            string postData = String.Format("client_id={0}&client_secret={1}&grant_type=client_credentials&scope={2}", 
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
                if (resp.StatusCode == HttpStatusCode.TooManyRequests && config.ControleRateLimit) {
                    Thread.Sleep(60000);
                    return ObterToken(config, scope, certificates);
                }
            }

            Token token = null;
            InterSdk.LogInfo("HTTPSTATUS {0}", resp.StatusCode.ToString());
            using (System.IO.Stream s = resp.GetResponseStream()) {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s)) {
                    string jsonResponse = sr.ReadToEnd();
                    int code = (int) resp.StatusCode;
                    if (config.Debug && code >= 400) {
                        InterSdk.LogInfo("RESPONSE {0}", jsonResponse);
                    }
                    token = (Token) SdkUtils.Deserialize(typeof(Token), jsonResponse);
                }
            }

            return token;
        }
    }
}

