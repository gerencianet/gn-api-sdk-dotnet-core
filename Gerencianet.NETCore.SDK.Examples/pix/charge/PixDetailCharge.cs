using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class PixDetailCharge
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
                
            var param = new {
                txid = ""
            };

            try {
                var response = endpoints.PixDetailCharge(param);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}