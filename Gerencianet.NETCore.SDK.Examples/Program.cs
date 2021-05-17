namespace Gerencianet.NETCore.SDK.Examples {
    internal class Program {
        private static void Main (string[] args) {

            /* PIX - WEBHOOK*/
            //PixConfigWebhook.Execute();
            //PixDeleteWebhook.Execute();
            //PixDetailWebhook.Execute();
            //PixListWebhook.Execute();
            
            /* PIX - CHARGE*/
            //PixCreateCharge.Execute();
            //PixCreateImmediateCharge.Execute();
            //PixDetailCharge.Execute();
            //PixListCharges.Execute();
            //PixUpdateCharge.Execute();
            
            /* PIX - PIX*/
            //PixDetail.Execute();
            //PixDevolution.Execute();
            //PixDetailDevolution.Execute();
            //PixListReceived.Execute();
            //PixSend.Execute();
            
            /* PIX - LOCATION*/
            //PixCreateLocation.Execute();
            //PixDetailLocation.Execute();
            //PixListLocation.Execute();
            //PixUnsetTxid.Execute();
            //PixGenerateQRCode.Execute();

            /* GN - KEY*/
            //GnListEvp.Execute();
            //GnCreateEvp.Execute();
            //GnDeleteEvp.Execute();

            /* GN - ACCOUNT*/
            //GnDetailBalance.Execute();
            //GnDetailSettings.Execute();
            //GnUpdateSettings.Execute();

            /* CHARGES */
            //OneStepBankingBillet.Execute ();
            //CreateCharge.Execute();
            //CreateChargeHistory.Execute();
            //DetailCharge.Execute();
            //ResendBillet.Execute();
            //UpdateBillet.Execute();
            //UpdateChargeMetadata.Execute();
            //CancelCharge.Execute();
            //SettleCharge.Execute();
            //CreateBilletPayment.Execute();
            //CreateCardPayment.Execute();
            //ChargeLink.Execute();

            /* SUBSCRIPTIONS */
            //CancelSubscription.Execute();
            //CreatePlan.Execute();
            //GetPlans.Execute();
            //DeletePlan.Execute();
            //CreateSubscription.Execute();
            //CreateSubscriptionHistory.Execute();
            //CreateSubscriptionPayment.Execute();
            //DetailSubscription.Execute();
            //UpdateSubscriptionMetadata.Execute();
            //UpdatePlan.Execute();

            /* CARNETS */
            //CancelCarnet.Execute();
            //CancelParcel.Execute();
            //CreateCarnet.Execute();
            //CreateCarnetHistory.Execute();
            //DetailCarnet.Execute();
            //ResendCarnet.Execute();
            //ResendParcel.Execute();
            //SettleCarnetParcel.Execute();
            //UpdateCarnetMetadata.Execute();
            //UpdateParcel.Execute();

            /* NOTIFICATIONS */
            //GetNotification.Execute();

            /* OTHER */
            //GetInstallments.Execute();

            //AllInOne.Execute();
        }
    }
}