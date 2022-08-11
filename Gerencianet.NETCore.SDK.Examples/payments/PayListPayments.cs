using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class PayListPayments {
        public static void Execute () {

            dynamic endpoints = new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
            
            var param = new {
                dataInicio = "2020-10-22",
                dataFim = "2023-06-23"
            };

            try {
                var response = endpoints.PayListPayments(param);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}