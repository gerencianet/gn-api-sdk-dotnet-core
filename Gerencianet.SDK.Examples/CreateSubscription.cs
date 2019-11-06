using System;

namespace Gerencianet.SDK.Examples {
    internal class CreateSubscription {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var planBody = new {
                name = "My first plan",
                repeats = 24,
                interval = 2
            };

            var subscriptionBody = new {
                items = new [] {
                new {
                name = "Product 1",
                value = 1000,
                amount = 2
                }
                }
            };

            try {
                var planResponse = endpoints.CreatePlan (null, planBody);

                var subscriptionParam = new {
                    id = planResponse.data.plan_id
                };
                var subscriptionResponse = endpoints.CreateSubscription (subscriptionParam, subscriptionBody);
                Console.WriteLine (subscriptionResponse);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}