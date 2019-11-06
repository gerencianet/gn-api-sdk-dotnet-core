using System;

namespace Gerencianet.SDK.Examples {
    internal class CreatePlan {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var body = new {
                name = "My first plan",
                repeats = 24,
                interval = 2
            };

            try {
                var response = endpoints.CreatePlan (null, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}