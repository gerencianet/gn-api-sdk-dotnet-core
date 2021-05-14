using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixListCharges
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                inicio = "2020-10-22T16:01:35Z",
                fim = "2021-04-23T16:01:35Z"
            };
            
            try {
                var response = endpoints.PixListCharges(param);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}