using System;

namespace Gerencianet.SDK.Examples {
    internal class UpdatePlans {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                id = 1001
            };

            var body = new {
                name = "My new plan"
            };

            try {
                var response = endpoints.UpdatePlan (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}