using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class ResendBillet {
        public static void Execute () {

            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                id = 1174
            };

            var body = new {
                email = "oldbuck@gerencianet.com.br"
            };

            try {
                var response = endpoints.ResendBillet (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}