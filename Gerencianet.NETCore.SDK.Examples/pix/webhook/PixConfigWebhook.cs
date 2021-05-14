using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixConfigWebhook
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var headers = "{\"x-skip-mtls-checking\": \"true\"}";

            var param = new {
                chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be"
            };

            var body = new {
                webhookUrl = "https://exemplo-pix/webhook"
            };

            try {
                var response = endpoints.PixConfigWebhook(param, body, headers);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}