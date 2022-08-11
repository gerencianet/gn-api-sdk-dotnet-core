using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using RestSharp;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections.Generic;


namespace Gerencianet.NETCore.SDK
{
    public class Endpoints : DynamicObject
    {
        private const string version = "3.0.0";
        private static string clientId;
        private static string clientSecret;
        private static JObject constants;
        private static JObject urls;
        private static string token = null;
        private static bool sandbox;
        private static string certificate;
        private string baseURL;


        public Endpoints(JObject options)
        {
            ClientId = (string)options["client_id"];
            ClientSecret = (string)options["client_secret"];
            Constants constant = new Constants();
            constants = JObject.Parse(constant.getConstant());
            Sandbox = (bool)options["sandbox"];
            Certificate = (string)options["certificate"];
        }

        public Endpoints(string clientId, string clientSecret, bool sandbox, string certificate)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Constants constant = new Constants();
            constants = JObject.Parse(constant.getConstant());
            Sandbox = sandbox;
            Certificate = certificate;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {

            JObject endpoint = null;

            if ((JObject)constants["APIS"]["PIX"]["ENDPOINTS"][binder.Name] != null)
            {
                urls = (JObject)constants["APIS"]["PIX"]["URL"];
                baseURL = Sandbox ? (string)urls["sandbox"] : (string)urls["production"];
                endpoint = (JObject)constants["APIS"]["PIX"]["ENDPOINTS"][binder.Name];
                if (Certificate == null)
                {
                    throw new GnException(1, "certificate_not_found", "Para utilizar os endpoints do pix é necessário informar o caminho do certificado.");
                }
            }
            else if ((JObject)constants["APIS"]["OPEN_FINANCE"]["ENDPOINTS"][binder.Name] != null)
            {
                urls = (JObject)constants["APIS"]["OPEN_FINANCE"]["URL"];
                baseURL = Sandbox ? (string)urls["sandbox"] : (string)urls["production"];
                endpoint = (JObject)constants["APIS"]["OPEN_FINANCE"]["ENDPOINTS"][binder.Name];
                if (Certificate == null)
                {
                    throw new GnException(1, "certificate_not_found", "Para utilizar os endpoints do Open Finance é necessário informar o caminho do certificado.");
                }
            }
            else if ((JObject)constants["APIS"]["PAGAMENTOS"]["ENDPOINTS"][binder.Name] != null)
            {
                urls = (JObject)constants["APIS"]["PAGAMENTOS"]["URL"];
                baseURL = Sandbox ? (string)urls["sandbox"] : (string)urls["production"];
                endpoint = (JObject)constants["APIS"]["PAGAMENTOS"]["ENDPOINTS"][binder.Name];
                if (Certificate == null)
                {
                    throw new GnException(1, "certificate_not_found", "Para utilizar os endpoints da API Pagamentos é necessário informar o caminho do certificado.");
                }
            }
            else if((JObject)constants["APIS"]["DEFAULT"]["ENDPOINTS"][binder.Name] != null)
            {
                urls = (JObject)constants["APIS"]["DEFAULT"]["URL"];
                baseURL = Sandbox ? (string)urls["sandbox"] : (string)urls["production"];
                endpoint = (JObject)constants["APIS"]["DEFAULT"]["ENDPOINTS"][binder.Name];
                Certificate = null;
            }

            if (endpoint == null)
                throw new GnException(0, "invalid_endpoint", string.Format("Método '{0}' inexistente", binder.Name));

            var route = (string)endpoint["route"];
            var method = (string)endpoint["method"];
            object body = null;
            object query = null;
            string headersComplement = null;

            if (args.Length > 0 && args[0] != null)
                query = args[0];

            if (args.Length > 1 && args[1] != null)
                body = args[1];

            if (args.Length > 2 && args[2] != null)
                headersComplement = (string)args[2];

            Authenticate();

            try
            {
                result = RequestEndpoint(route, method, query, body, headersComplement);
                return true;
            }
            catch (GnException e)
            {
                if (e.Code == 401)
                {
                    Authenticate();
                    result = RequestEndpoint(route, method, query, body, headersComplement);
                    return true;
                }

                throw e;
            }
        }
        private void Authenticate()
        {
            var credentials = string.Format("{0}:{1}", ClientId, ClientSecret);
            var encodedAuth = Convert.ToBase64String(Encoding.GetEncoding("UTF-8").GetBytes(credentials));
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Authorization", string.Format("Basic {0}", encodedAuth));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestResponse restResponse;

            if (Certificate != null)
            {
                var x509Certificate2 = new X509Certificate2(certificate, "", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);

                var client = new RestClient(new RestClientOptions(baseURL + "/oauth/token")
                {
                    ClientCertificates = new X509CertificateCollection() { x509Certificate2 }
                });
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\r\n    \"grant_type\": \"client_credentials\"\r\n}", ParameterType.RequestBody);
                restResponse = client.Execute(request);
            }
            else
            {
                var client = new RestClient(baseURL + "/authorize");
                request.AddJsonBody("{\r\n    \"grant_type\": \"client_credentials\"\r\n}");
                restResponse = client.Execute(request);
            }

            string response = restResponse.Content;
            JObject json = JObject.Parse(response);
            Token = json["access_token"].ToString();
        }
        private object RequestEndpoint(string endpoint, string method, object query, object body, string headersComplement)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string newEndpoint = GetEndpointRequest(endpoint, method, query);

            var request = new RestRequest();

            if (method == "PUT") request.Method = Method.Put;
            else if (method == "GET") request.Method = Method.Get;
            else if (method == "POST") request.Method = Method.Post;
            else if (method == "DELETE") request.Method = Method.Delete;
            else if (method == "PATCH") request.Method = Method.Patch;

            request.AddHeader("Authorization", string.Format("Bearer {0}", Token));
            request.AddHeader("api-sdk", string.Format("dotnet-core-{0}", version));

            if (headersComplement != null)
            {

                var header = JObject.Parse(headersComplement);
                if (header["x-skip-mtls-checking"] != null)
                    request.AddHeader("x-skip-mtls-checking", (string)header["x-skip-mtls-checking"]);
                if (header["x-idempotency-key"] != null)
                    request.AddHeader("x-idempotency-key", (string)header["x-idempotency-key"]);
            }

            try
            {
                return SendRequest(request, body, newEndpoint);
            }
            catch (WebException e)
            {
                if (e.Response != null && e.Response is HttpWebResponse)
                {
                    var statusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                    var reader = new StreamReader(e.Response.GetResponseStream());
                    throw GnException.Build(reader.ReadToEnd(), statusCode);
                }
                throw GnException.Build("", 500);
            }
        }

        public string GetEndpointRequest(string endpoint, string method, object query)
        {
            if (query != null)
            {
                var attr = BindingFlags.Public | BindingFlags.Instance;
                var queryDict = new Dictionary<string, object>();
                foreach (var property in query.GetType().GetProperties(attr))
                    if (property.CanRead)
                        queryDict.Add(property.Name, property.GetValue(query, null));

                var matchCollection = Regex.Matches(endpoint, ":([a-zA-Z0-9]+)");
                for (var i = 0; i < matchCollection.Count; i++)
                {
                    var resource = matchCollection[i].Groups[1].Value;
                    try
                    {
                        var value = queryDict[resource].ToString();
                        endpoint = Regex.Replace(endpoint, string.Format(":{0}", resource), value);
                        queryDict.Remove(resource);
                    }
                    catch (Exception) { }
                }

                var queryString = "";
                foreach (var pair in queryDict)
                {
                    if (queryString.Equals(""))
                        queryString = "?";
                    else
                        queryString += "&";
                    queryString += string.Format("{0}={1}", pair.Key, pair.Value);
                }

                endpoint += queryString;
            }

            return endpoint;
        }

        public dynamic SendRequest(RestRequest request, object body, string newEndpoint)
        {

            if (body != null)
                request.AddJsonBody(body);

            var client = new RestClient(baseURL + newEndpoint);

            if (certificate != null)
            {
                var x509Certificate2 = new X509Certificate2(certificate, "", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);

                client = new RestClient(new RestClientOptions(baseURL + newEndpoint)
                {
                    ClientCertificates = new X509CertificateCollection() { x509Certificate2 }
                });
            }

            RestResponse restResponse = client.Execute(request);
            string response = restResponse.Content;
            return response;
        }

        private static string ClientId { get => clientId; set => clientId = value; }
        public static string ClientSecret { get => clientSecret; set => clientSecret = value; }
        public static bool Sandbox { get => sandbox; set => sandbox = value; }
        public static string Certificate { get => certificate; set => certificate = value; }
        public static string Token { get => token; set => token = value; }
    }
}
