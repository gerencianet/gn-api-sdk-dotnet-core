using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixUpdateCharge
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
                
            var param = new {
                txid = "e4caf2374a684d40b6e7a152bebdac67"
            };

            var body = new {
                calendario = new {
                    expiracao = 3600
                },
                devedor = new {
                    cpf = "12345678909",
                    nome = "Francisco da Silva"
                },
                valor = new {
                    original = "123.45"
                },
                chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be",
                solicitacaoPagador = "Informe o número ou identificador do pedido."
            };

            try {
                var response = endpoints.PixUpdateCharge(param, body);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}