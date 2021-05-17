using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class UpdateChargeLink {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

            var param = new {
                id = 1000
            };

            var body = new {
                billet_discount = 0,
                card_discount = 0,
                message = "",
                expire_at = DateTime.Now.AddDays (3).ToString ("yyyy-MM-dd"),
                request_delivery_address = false,
                payment_method = "all"
            };

            try {
                var response = endpoints.UpdateChargeLink (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}