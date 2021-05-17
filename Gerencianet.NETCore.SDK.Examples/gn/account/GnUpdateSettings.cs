using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples
{
    class GnUpdateSettings
    {
        public static void Execute()
        {
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            string body = "{\"pix\": { \"receberSemChave\": true, \"chaves\": {\"InformeAquiSuaChave\": {\"recebimento\": {                    \"txidObrigatorio\": false, \"qrCodeEstatico\": { \"recusarTodos\": false }}}}}}";

            try {
                var response = endpoints.GnUpdateSettings(null, body);
                Console.WriteLine(response);
            } catch (GnException e) {
                Console.WriteLine(e.ErrorType);
                Console.WriteLine(e.Message);
            }
        }
    }
}