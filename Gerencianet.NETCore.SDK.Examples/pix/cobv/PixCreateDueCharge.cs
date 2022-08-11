using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Gerencianet.NETCore.SDK.Examples {
    internal class PixCreateDueCharge {
        public static void Execute () {

            dynamic endpoints = new Endpoints(JObject.Parse (File.ReadAllText ("credentials.json")));
            
            var param = new {
                txid = "txistxidstxidtxistsgdkjjgkj7",
            };

            var body = new {
                calendario = new {
                    dataDeVencimento = "2022-12-01",
                    validadeAposVencimento = 30
                },
                devedor = new {
                    logradouro = "Alameda Souza, Numero 80, Bairro Braz",
                    cidade = "Recife",
                    uf = "PE",
                    cep = "70011750",
                    cpf = "12345678909",
                    nome = "Francisco da Silva"
                },
                valor = new {
                    original = "123.45",
                    multa = new {
                        modalidade = 2,
                        valorPerc = "15.00"
                    },
                    juros = new {
                        modalidade = 2,
                        valorPerc = "2.00"
                    },
                    desconto = new {
                        modalidade = 1,
                        descontoDataFixa = new []{
                        new {
                            data = "2022-11-30",
                            valorPerc = "30.00"
                            }
                        }
                    }
                },
                chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be",
                solicitacaoPagador = "Cobrança dos serviços prestados."
            };

            try {
                var response = endpoints.PixCreateDueCharge(param, body);
                Console.WriteLine (response);
            } catch (GnException e) {
                Console.WriteLine (e.ErrorType);
                Console.WriteLine (e.Message);
            }
        }
    }
}