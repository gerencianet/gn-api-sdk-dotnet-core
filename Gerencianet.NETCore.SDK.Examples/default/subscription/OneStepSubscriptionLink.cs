using System;
using System.IO;
using Newtonsoft.Json.Linq;


namespace Gerencianet.NETCore.SDK.Examples {
    internal class OneStepSubscriptionLink {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                id = 1
            };

            var body = new {
                items = new [] {
                    new {
                        name = "Product 1",
                        value = 590,
                        amount = 2
                    }
                },
                settings = new {
                    payment_method = "all",
                    expire_at = "2022-12-15",
                    request_delivery_address = false
                }
            };

            try {
                var response = endpoints.OneStepSubscriptionLink(param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}