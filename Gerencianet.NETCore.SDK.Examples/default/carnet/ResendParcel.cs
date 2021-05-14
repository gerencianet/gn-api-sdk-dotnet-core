using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class ResendParcel {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                id = 1001,
                parcel = 2
            };

            var body = new {
                email = "oldbuck@gerencianet.com.br"
            };

            try {
                var response = endpoints.ResendParcel (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}