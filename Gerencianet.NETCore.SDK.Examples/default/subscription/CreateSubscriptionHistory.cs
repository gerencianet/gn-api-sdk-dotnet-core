using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class CreateSubscriptionHistory {
        public static void Execute () {

            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
            
            var param = new {
                id = 1000
            };

            var body = new {
                description = "This subscription was not fully paid"
            };

            try {
                var response = endpoints.CreateSubscriptionHistory (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}