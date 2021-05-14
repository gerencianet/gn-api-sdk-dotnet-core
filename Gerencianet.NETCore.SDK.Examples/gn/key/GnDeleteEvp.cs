using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class GnDeleteEvp
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
                
            var param = new {
                chave = ""
            };

            try{
                var response = endpoints.GnDeleteEvp(param, null);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}