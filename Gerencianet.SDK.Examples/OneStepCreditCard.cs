using System;

namespace Gerencianet.SDK.Examples {
    internal class OneStepCreditCard {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);
            var body = new {
                items = new [] {
                new {
                name = "Product 1",
                value = 590,
                amount = 2
                }
                },
                shippings = new [] {
                new {
                name = "Default Shipping Cost",
                value = 10
                }
                },
                payment = new {
                credit_card = new {
                installments = 1,
                payment_token = "7d0a3fe0f0c9caab4f3b6578317a9d7e8ed6303f",
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
                var response = endpoints.OneStep (null, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}