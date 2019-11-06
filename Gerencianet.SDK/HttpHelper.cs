using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gerencianet.SDK {
    public class HttpHelper {
        public string BaseUrl { get; set; }

        public WebRequest GetWebRequest (string endpoint, string method, object query) {
            if (query != null) {
                var attr = BindingFlags.Public | BindingFlags.Instance;
                var queryDict = new Dictionary<string, object> ();
                foreach (var property in query.GetType ().GetProperties (attr))
                    if (property.CanRead)
                        queryDict.Add (property.Name, property.GetValue (query, null));

                var matchCollection = Regex.Matches (endpoint, ":([a-zA-Z0-9]+)");
                for (var i = 0; i < matchCollection.Count; i++) {
                    var resource = matchCollection[i].Groups[1].Value;
                    try {
                        var value = queryDict[resource].ToString ();
                        endpoint = Regex.Replace (endpoint, string.Format (":{0}", resource), value);
                        queryDict.Remove (resource);
                    } catch (Exception) { }
                }

                var queryString = "";
                foreach (var pair in queryDict) {
                    if (queryString.Equals (""))
                        queryString = "?";
                    else
                        queryString += "&";
                    queryString += string.Format ("{0}={1}", pair.Key, pair.Value);
                }

                endpoint += queryString;
            }

            var request = WebRequest.Create (string.Format ("{0}{1}", BaseUrl, endpoint));
            request.Method = method;
            request.ContentType = "application/json";

            return request;
        }

        public dynamic SendRequest (WebRequest request, object body) {
            if (!request.Method.Equals ("GET") && body != null)
                using (var postStream = request.GetRequestStream ()) {
                    var data = Encoding.UTF8.GetBytes (JObject.FromObject (body).ToString ());
                    postStream.Write (data, 0, data.Length);
                }

            using (var response = request.GetResponse ()) {
                var reader = new StreamReader (response.GetResponseStream ());
                object def = new { };
                return JsonConvert.DeserializeAnonymousType (reader.ReadToEnd (), def);
            }
        }
    }
}