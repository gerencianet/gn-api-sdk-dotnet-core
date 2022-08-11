using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class PixUpdateDueCharge {
        public static void Execute () {

            dynamic endpoints = new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
            
            var param = new {
                txid = "txistxidstxidtxistsgdkjjgkj7",
            };

            var body = new {
                devedor = new {
                    logradouro = "Alameda Souza, Numero 80, Bairro Braz",
                    cidade = "Recife",
                    uf = "PE",
                    cep = "70011750",
                    cpf = "12345678909",
                    nome = "Francisco da Silva"
                },
                valor = new {
                    original = "123.50",
                },
                solicitacaoPagador = "Cobrança dos serviços prestados..."
            };

            try {
                var response = endpoints.PixUpdateDueCharge(param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}