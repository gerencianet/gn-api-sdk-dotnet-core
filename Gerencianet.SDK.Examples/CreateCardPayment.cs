using System;

namespace Gerencianet.SDK.Examples {
    internal class CreateCardPayment {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                id = 1000
            };

            var body = new {
                payment = new {
                credit_card = new {
                installments = 1,
                payment_token = "6426f3abd8688639c6772963669bbb8e0eb3c319",
                billing_address = new {
                street = "Av. JK",
                number = 909,
                neighborhood = "Bauxita",
                zipcode = "35400000",
                city = "Ouro Preto",
                state = "MG"
                },
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