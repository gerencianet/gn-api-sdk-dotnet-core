using System;

namespace Gerencianet.SDK.Examples {
    internal class SettleCarnetParcel {
        public static void Execute () {
            dynamic endpoints = new Endpoints (Credentials.ClientId, Credentials.ClientSecret,
                Credentials.Sandbox);

            var param = new {
                id = 0,
                parcel = 1
            };

            try {
                var response = endpoints.SettleCarnetParcel (param);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}