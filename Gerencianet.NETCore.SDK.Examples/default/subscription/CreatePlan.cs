using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class CreatePlan {
        public static void Execute () {

            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var body = new {
                name = "My first plan",
                repeats = 24,
                interval = 2
            };

            try {
                var response = endpoints.CreatePlan (null, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}