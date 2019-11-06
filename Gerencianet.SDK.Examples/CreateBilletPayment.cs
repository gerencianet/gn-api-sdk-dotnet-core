using System;

namespace Gerencianet.SDK.Examples {
    internal class CreateBilletPayment {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                id = 1000
            };

            var body = new {
                payment = new {
                banking_billet = new {
                expire_at = DateTime.Now.AddDays (1).ToString ("yyyy-MM-dd"),
                customer = new {
                name = "Gorbadoc Oldbuck",
                email = "oldbuck@gerencianet.com.br",
                cpf = "04267484171",
                birth = "1977-01-15",
                phone_number = "5144916523"
                }
                }
                }
            };

            try {
                var response = endpoints.PayCharge (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}