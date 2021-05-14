using Newtonsoft.Json;

namespace Gerencianet.NETCore.SDK {
    public class Constants{
        public object Const = new {
                    URLS = new {
                        DEFAULT = new {
                            production = "https://api.gerencianet.com.br/v1",
                            sandbox = "https://sandbox.gerencianet.com.br/v1"
                        },
                        PIX = new {
                            production = "https://api-pix.gerencianet.com.br",
                            sandbox = "https://api-pix-h.gerencianet.com.br"
                        }
                    },
                    ENDPOINTS = new {
                        DEFAULT = new {
                            CreateCharge = new {
                                route = "/charge",
                                method =  "POST"
                            },
                            DetailCharge = new {
                                route = "/charge/:id",
                                method = "GET"
                            },
                            UpdateChargeMetadata = new {
                                route = "/charge/:id/metadata",
                                method = "PUT"
                            },
                            UpdateBillet = new {
                                route = "/charge/:id/billet",
                                method = "PUT"
                            },
                            PayCharge = new {
                                route = "/charge/:id/pay",
                                method = "POST"
                            },
                            CancelCharge = new {
                                route = "/charge/:id/cancel",
                                method = "PUT"
                            },
                            CreateCarnet = new {
                                route = "/carnet",
                                method = "POST"
                            },
                            DetailCarnet = new {
                                route = "/carnet/:id",
                                method = "GET"
                            },
                            UpdateParcel = new {
                                route = "/carnet/:id/parcel/:parcel",
                                method = "PUT"
                            },
                            UpdateCarnetMetadata = new {
                                route = "/carnet/:id/metadata",
                                method = "PUT"
                            },
                            GetNotification = new {
                                route = "/notification/:token",
                                method = "GET"
                            },
                            GetPlans = new {
                                route = "/plans",
                                method = "GET"
                            },
                            CreatePlan = new {
                                route = "/plan",
                                method = "POST"
                            },
                            DeletePlan = new {
                                route = "/plan/:id",
                                method = "DELETE"
                            },
                            CreateSubscription = new {
                                route = "/plan/:id/subscription",
                                method = "POST"
                            },
                            DetailSubscription = new {
                                route = "/subscription/:id",
                                method = "GET"
                            },
                            PaySubscription = new {
                                route = "/subscription/:id/pay",
                                method = "POST"
                            },
                            CancelSubscription = new {
                                route = "/subscription/:id/cancel",
                                method = "PUT"
                            },
                            UpdateSubscriptionMetadata = new {
                                route = "/subscription/:id/metadata",
                                method = "PUT"
                            },
                            GetInstallments = new {
                                route = "/installments",
                                method = "GET"
                            },
                            ResendBillet = new {
                                route = "/charge/:id/billet/resend",
                                method = "POST"
                            },
                            CreateChargeHistory = new {
                                route = "/charge/:id/history",
                                method = "POST"
                            },
                            ResendCarnet = new {
                                route = "/carnet/:id/resend",
                                method = "POST"
                            },
                            ResendParcel = new {
                                route = "/carnet/:id/parcel/:parcel/resend",
                                method = "POST"
                            },
                            CreateCarnetHistory = new {
                                route = "/carnet/:id/history",
                                method = "POST"
                            },
                            CancelCarnet = new {
                                route = "/carnet/:id/cancel",
                                method = "PUT"
                            },
                            CancelParcel = new {
                                route = "/carnet/:id/parcel/:parcel/cancel",
                                method = "PUT"
                            },
                            LinkCharge = new {
                                route = "/charge/:id/link",
                                method = "POST"
                            },
                            ChargeLink = new {
                                route = "/charge/:id/link",
                                method = "POST"
                            },
                            UpdateChargeLink = new {
                                route = "/charge/:id/link",
                                method = "PUT"
                            },
                            UpdatePlan = new {
                                route = "/plan/:id",
                                method = "PUT"
                            },
                            CreateSubscriptionHistory = new {
                                route = "/subscription/:id/history",
                                method = "POST"
                            },
                            SettleCharge = new {
                                route = "/charge/:id/settle",
                                method = "PUT"
                            },
                            SettleCarnetParcel = new {
                                route = "/carnet/:id/parcel/:parcel/settle",
                                method = "PUT"
                            },
                            OneStep = new {
                                route = "/charge/one-step",
                                method = "POST"
                            }
                        },
                        PIX = new {
                            authorize = new {
                                route = "/oauth/token",
                                method = "POST"
                            },
                            PixConfigWebhook = new {
                                route = "/v2/webhook/:chave",
                                method = "PUT"
                            },
                            PixDetailWebhook = new {
                                route = "/v2/webhook/:chave",
                                method = "GET"
                            },
                            PixListWebhook = new {
                                route = "/v2/webhook",
                                method = "GET"
                            },
                            PixDeleteWebhook = new {
                                route = "/v2/webhook/:chave",
                                method = "DELETE"
                            },
                            PixCreateCharge = new {
                                route = "/v2/cob/:txid",
                                method = "PUT"
                            },
                            PixCreateImmediateCharge = new {
                                route = "/v2/cob",
                                method = "POST"
                            },
                            PixDetailCharge = new {
                                route = "/v2/cob/:txid",
                                method = "GET"
                            },
                            PixUpdateCharge = new {
                                route = "/v2/cob/:txid",
                                method = "PATCH"
                            },
                            PixListCharges = new {
                                route = "/v2/cob",
                                method = "GET"
                            },
                            PixGenerateQRCode = new {
                                route = "/v2/loc/:id/qrcode",
                                method = "GET"
                            },
                            PixDevolution = new {
                                route = "/v2/pix/:e2eId/devolucao/:id",
                                method = "PUT"
                            },
                            PixDetailDevolution = new {
                                route = "/v2/pix/:e2eId/devolucao/:id",
                                method = "GET"
                            },
                            PixSend = new {
                                route = "/v2/pix",
                                method = "POST"
                            },
                            PixDetail = new {
                                route = "/v2/pix/:e2eId",
                                method = "GET"
                            },
                            PixListReceived = new {
                                route = "/v2/pix",
                                method = "GET"
                            },
                            PixCreateLocation = new {
                                route = "/v2/loc",
                                method = "POST"
                            },
                            PixListLocation = new {
                                route = "/v2/loc",
                                method = "GET"
                            },
                            PixDetailLocation = new {
                                route = "/v2/loc/:id",
                                method = "GET"
                            },
                            PixUnsetTxid = new {
                                route = "/v2/loc/:id/txid",
                                method = "DELETE"
                            },
                            GnCreateEvp = new {
                                route = "/v2/gn/evp",
                                method = "POST"
                            },
                            GnListEvp = new {
                                route = "/v2/gn/evp",
                                method = "GET"
                            },
                            GnDeleteEvp = new {
                                route = "/v2/gn/evp/:chave",
                                method = "DELETE"
                            },
                            GnDetailBalance = new {
                                route = "/v2/gn/saldo",
                                method = "GET"
                            },
                            GnUpdateSettings = new {
                                route = "/v2/gn/config",
                                method = "PUT"
                            },
                            GnDetailSettings = new {
                                route = "/v2/gn/config",
                                method = "GET"
                            }
                        }
                    }
                };

            public string getConstant(){
                string jsonString = JsonConvert.SerializeObject(Const);
                return jsonString;
            }
    }
}
