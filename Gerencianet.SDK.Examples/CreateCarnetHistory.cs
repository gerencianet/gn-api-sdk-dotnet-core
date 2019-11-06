using System;

namespace Gerencianet.SDK.Examples {
    internal class CreateCarnetHistory {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                id = 1001
            };

            var body = new {
                description = "This carnet is about a service"
            };

            try {
                var response = endpoints.CreateCarnetHistory (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}