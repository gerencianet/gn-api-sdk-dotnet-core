using System;

namespace Gerencianet.SDK.Examples {
    internal class GetPlans {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                // name = "My Plan",
                limit = 20,
                offset = 0
            };

            try {
                var response = endpoints.GetPlans (param);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}