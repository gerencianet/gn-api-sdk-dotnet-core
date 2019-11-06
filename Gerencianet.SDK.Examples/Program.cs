namespace Gerencianet.SDK.Examples {
    internal class Program {
        private static void Main (string[] args) {
            /* CHARGES */
            OneStepBankingBillet.Execute ();
            //CreateChargeHistory.Execute();
            //DetailCharge.Execute();
            //ResendBillet.Execute();
            //UpdateBillet.Execute();
            //UpdateCarnetMetadata.Execute();
            //CancelCharge.Execute();
            //SettleCharge.Execute();

            //CreateBilletPayment.Execute();
            //CreateCardPayment.Execute();

            /* SUBSCRIPTIONS */
            //CreatePlan.Execute();
            //GetPlans.Execute();
            //DeletePlan.Execute();
            //CreateSubscription.Execute();
            //CreateSubscriptionPayment.Execute();
            //DetailSubscription.Execute();
            //UpdateSubscriptionMetadata.Execute();
            //CancelSubscription.Execute();

            /* CARNETS */
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