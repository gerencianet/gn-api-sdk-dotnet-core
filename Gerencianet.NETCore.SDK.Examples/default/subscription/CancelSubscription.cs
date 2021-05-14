using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class CancelSubscription {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                id = 0
            };

            try {
                var response = endpoints.CancelSubscription (param);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}