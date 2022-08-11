using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class PayRequestBarCode {
        public static void Execute () {

            dynamic endpoints = new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
            
            var param = new {
                codBarras = ""
            };

            var body = new {
                valor = 1,
                dataPagamento = "2022-06-17",
                descricao = "Pagamento de boleto."
            };

            try {
                var response = endpoints.PayRequestBarCode(param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}