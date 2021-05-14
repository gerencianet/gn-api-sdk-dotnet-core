using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class GetInstallments {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                brand = "visa",
                total = 2500
            };

            try {
                var response = endpoints.GetInstallments (param);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}