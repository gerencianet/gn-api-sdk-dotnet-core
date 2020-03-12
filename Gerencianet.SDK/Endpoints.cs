using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Gerencianet.SDK {
    public class Endpoints : DynamicObject {
        private const string apiBaseURL = "https://api.gerencianet.com.br/v1";
        private const string apiBaseSandboxURL = "https://sandbox.gerencianet.com.br/v1";
        private const string version = "1.0.0";
        private static string clientId;
        private static string clientSecret;
        private static JObject endpoints;
        private static HttpHelper httpHelper;
        private static string token = null;
        private static string partnerToken = null;

        public Endpoints (string clientId, string clientSecret, bool sandbox) {
            ClientId = clientId;
            ClientSecret = clientSecret;            
            string rootDir  = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace("file://",""));
            string filePath = System.IO.Path.Combine(rootDir,"endpoints.json");
            endpoints = JObject.Parse (File.ReadAllText (filePath));
            HttpHelper = new HttpHelper ();
            HttpHelper.BaseUrl = sandbox ? apiBaseSandboxURL : apiBaseURL;
        }

        public Endpoints (string clientId, string clientSecret, bool sandbox, string partnerToken) : this (clientId, clientSecret, sandbox) {
            if (partnerToken != "")
                PartnerToken = partnerToken;
        }

        public override bool TryInvokeMember (InvokeMemberBinder binder, object[] args, out object result) {
            JObject endpoint = null;
            endpoint = (JObject) endpoints[binder.Name];

            if (endpoint == null)
                throw new GnException (0, "invalid_endpoint", string.Format ("Método '{0}' inexistente", binder.Name));

            var route = (string) endpoint["route"];
            var method = (string) endpoint["method"];
            object body = new { };
            object query = new { };

            if (args.Length > 0 && args[0] != null)
                query = args[0];

            if (args.Length > 1 && args[1] != null)
                body = args[1];

            if (Token == null)
                Authenticate ();

            try {
                result = RequestEndpoint (route, method, query, body);
                return true;
            } catch (GnException e) {
                if (e.Code == 401) {
                    Authenticate ();
                    result = RequestEndpoint (route, method, query, body);
                    return true;
                }

                throw e;
            }
        }
        private void Authenticate () {
            object body = new {
                grant_type = "client_credentials"
            };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = HttpHelper.GetWebRequest ("/authorize", "post", null);
            var credentials = string.Format ("{0}:{1}", ClientId, ClientSecret);
            var encodedAuth = Convert.ToBase64String (Encoding.GetEncoding ("UTF-8").GetBytes (credentials));
            request.Headers.Add ("Authorization", string.Format ("Basic {0}", encodedAuth));
            request.Headers.Add ("api-sdk", string.Format ("dotnet-core-{0}", version));

            try {
                var response = HttpHelper.SendRequest (request, body);
                Token = response.access_token;
            } catch (WebException) {
                throw GnException.Build ("", 401);
            }
        }
        private object RequestEndpoint (string endpoint, string method, object query, object body) {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = HttpHelper.GetWebRequest (endpoint, method, query);
            request.Headers.Add ("Authorization", string.Format ("Bearer {0}", Token));
            request.Headers.Add ("api-sdk", string.Format ("dotnet-core-{0}", version));
            if (PartnerToken != null) request.Headers.Add ("partner-token", PartnerToken);

            try {
                return HttpHelper.SendRequest (request, body);
            } catch (WebException e) {
                if (e.Response != null && e.Response is HttpWebResponse) {
                    var statusCode = (int) ((HttpWebResponse) e.Response).StatusCode;
                    var reader = new StreamReader (e.Response.GetResponseStream ());
                    throw GnException.Build (reader.ReadToEnd (), statusCode);
                }

                throw GnException.Build ("", 500);
            }
        }
        private static string ClientId { get => clientId; set => clientId = value; }
        public static string ClientSecret { get => clientSecret; set => clientSecret = value; }
        public static string PartnerToken { get => partnerToken; set => partnerToken = value; }
        public static HttpHelper HttpHelper { get => httpHelper; set => httpHelper = value; }
        public static string Token { get => token; set => token = value; }
    }
}