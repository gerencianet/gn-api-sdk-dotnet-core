using System;
using System.IO;
using Newtonsoft.Json.Linq;


namespace Gerencianet.NETCore.SDK.Examples {
    internal class OneStepBankingBillet {
        public static void Execute () {
            
            dynamic endpoints =  new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));

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
                },
                payment = new {
                    banking_billet = new {
                        expire_at = DateTime.Now.AddDays (1).ToString ("yyyy-MM-dd"),
                        customer = new {
                            name = "Gorbadoc Oldbuck",
                            email = "oldbuck@gerencianet.com.br",
                            cpf = "94271564656",
                            birth = "1977-01-15",
                            phone_number = "5144976523"
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