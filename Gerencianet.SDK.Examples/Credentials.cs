namespace Gerencianet.SDK.Examples {

    public class Credentials {
        private static string clientId = "";
        private static string clientSecret = "";
        private static bool sandbox = true;
        private static string partnerToken = "";

        public static string ClientId {
            get => clientId;
            set => clientId = value;
        }
        public static string ClientSecret {
            get => clientSecret;
            set => clientSecret = value;
        }
        public static bool Sandbox {
            get => sandbox;
            set => sandbox = value;
        }
        public static string PartnerToken {
            get => partnerToken;
            set => partnerToken = value;
        }
    }
}