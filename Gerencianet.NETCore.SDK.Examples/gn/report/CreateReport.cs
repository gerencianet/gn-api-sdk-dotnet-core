using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class CreateReport {
        public static void Execute () {

            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var body = new {
                dataMovimento = "2022-04-24",
                tipoRegistros = new {
                    pixRecebido = true,
                    pixDevolucaoEnviada = false,
                    tarifaPixRecebido = true,
                    pixEnviadoChave = true,
                    pixEnviadoDadosBancarios = false,
                    pixDevolucaoRecebida = true
                }
            };

            try {
                var response = endpoints.CreateReport(null, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}