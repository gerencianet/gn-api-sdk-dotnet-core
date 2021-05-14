using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixSend
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
                
            var body = new {
                valor = "0.01",
                pagador = new {
                    chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be",
                },
                favorecido = new {
                    chave = "12345678909"
                }
            };

            try {
                var response = endpoints.PixSend(null, body);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
            
        }
    }
}