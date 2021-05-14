using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixCreateCharge
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                txid = ""
            };

            var body = new
            {
                calendario = new {
                    expiracao = 100000
                },
                devedor = new {
                    cpf = "12345678909",
                    nome = "Francisco da Silva"
                },
                valor = new {
                    original = "0.03"
                },
                chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be",
                solicitacaoPagador = "Informe o número ou identificador do pedido."
            };

            try{
                var response = endpoints.PixCreateCharge(param, body);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }

        }
    }
}