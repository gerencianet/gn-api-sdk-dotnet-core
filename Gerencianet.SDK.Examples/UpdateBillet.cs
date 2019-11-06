using System;

namespace Gerencianet.SDK.Examples {
    internal class UpdateBillet {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                id = 1174
            };

            var body = new {
                expire_at = "2020-12-20"
            };

            try {
                var response = endpoints.UpdateBillet (param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}