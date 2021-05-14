using System;
using System.IO;
using Newtonsoft.Json.Linq;


namespace Gerencianet.NETCore.SDK.Examples
{
    class PixDeleteWebhook
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
                
            var param = new {
                chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be"
            };

            try {
                var response = endpoints.PixDeleteWebhook(param);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}