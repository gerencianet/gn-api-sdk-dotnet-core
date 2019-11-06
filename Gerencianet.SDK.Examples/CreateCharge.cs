using System;

namespace Gerencianet.SDK.Examples {
    internal class CreateCharge {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox, Credentials.PartnerToken);

            var body = new {
                items = new [] {
                new {
                name = "Product 1",
                value = 1000,
                amount = 2
                }
                },
                shippings = new [] {
                new {
                name = "Default Shipping Cost",
                value = 100
                }
                }
            };

            try {
                var response = endpoints.CreateCharge (null, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}