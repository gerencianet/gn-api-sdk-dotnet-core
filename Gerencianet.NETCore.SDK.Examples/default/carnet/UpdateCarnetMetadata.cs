using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class UpdateCarnetMetadata {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                id = 1
            };

            var body = new {
                notification_url = "http://yourdomain.com",
                custom_id = "my_new_id"
            };

            try {
                var response = endpoints.UpdateCarnetMetadata (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}