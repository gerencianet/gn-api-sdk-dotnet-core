using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class PayDetailPayment {
        public static void Execute () {

            dynamic endpoints = new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
            
            var param = new {
                idPagamento = 1
            };

            try {
                var response = endpoints.PayDetailPayment(param);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}