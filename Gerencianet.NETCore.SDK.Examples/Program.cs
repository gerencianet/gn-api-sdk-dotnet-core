using System;

namespace Gerencianet.NETCore.SDK.Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* PIX - WEBHOOK */
            // PixConfigWebhook.Execute();
            // PixDeleteWebhook.Execute();
            // PixDetailWebhook.Execute();
            // PixListWebhook.Execute();
            
            /* PIX - CHARGE */
            // PixCreateCharge.Execute();
            // PixCreateImmediateCharge.Execute();
            // PixDetailCharge.Execute();
            // PixListCharges.Execute();
            // PixUpdateCharge.Execute();

            /* PIX - COBV */
            // PixCreateDueCharge.Execute();
            // PixUpdateDueCharge.Execute();
            // PixDetailDueCharge.Execute();
            // PixListDueCharges.Execute();
            
            /* PIX - PIX */
            // PixDetail.Execute();
            // PixDevolution.Execute();
            // PixDetailDevolution.Execute();
            // PixListReceived.Execute();
            // PixSend.Execute();
            
            /* PIX - LOCATION */
            // PixCreateLocation.Execute();
            // PixDetailLocation.Execute();
            // PixListLocation.Execute();
            // PixUnsetTxid.Execute();
            // PixGenerateQRCode.Execute();

            /* GN - KEY */
            // GnListEvp.Execute();
            // GnCreateEvp.Execute();
            // GnDeleteEvp.Execute();

            /* GN - ACCOUNT */
            // GnDetailBalance.Execute();
            // GnDetailSettings.Execute();
            // GnUpdateSettings.Execute();

            /* GN - REPORT */
            // CreateReport.Execute();
            // DetailReport.Execute();

            /* CHARGES */
            // OneStepBankingBillet.Execute ();
            // CreateCharge.Execute();
            // CreateChargeHistory.Execute();
            // DetailCharge.Execute();
            // ResendBillet.Execute();
            // UpdateBillet.Execute();
            // UpdateChargeMetadata.Execute();
            // CancelCharge.Execute();
            // SettleCharge.Execute();
            // CreateBilletPayment.Execute();
            // CreateCardPayment.Execute();
            // ChargeLink.Execute();
            // OneStepLink.Execute();
            // ResendChargeLink.Execute();

            /* SUBSCRIPTIONS */
            // CancelSubscription.Execute();
            // CreatePlan.Execute();
            // GetPlans.Execute();
            // DeletePlan.Execute();
            // CreateSubscription.Execute();
            // CreateSubscriptionHistory.Execute();
            // CreateSubscriptionPayment.Execute();
            // DetailSubscription.Execute();
            // UpdateSubscriptionMetadata.Execute();
            // UpdatePlan.Execute();
            // OneStepSubscriptionLink.Execute();
            // OneStepSubscription.Execute();
            // ResendSubscriptionCharge.Execute();

            /* CARNETS */
            // CancelCarnet.Execute();
            // CancelParcel.Execute();
            // CreateCarnet.Execute();
            // CreateCarnetHistory.Execute();
            // DetailCarnet.Execute();
            // ResendCarnet.Execute();
            // ResendParcel.Execute();
            // SettleCarnet.Execute();
            // SettleCarnetParcel.Execute();
            // UpdateCarnetMetadata.Execute();
            // UpdateParcel.Execute();

            /* NOTIFICATIONS */
            //GetNotification.Execute();

            /* OTHER */
            // GetInstallments.Execute();

            /* OPEN FINANCE */
            // OfUpdateSettings.Execute();
            // OfDetailSettings.Execute();
            // OfListParticipants.Execute();
            // OfStartPixPayment.Execute();
            // OfListPixPayment.Execute();

            /* PAYMENTS */
            // PayDetailBarCode.Execute();
            // PayRequestBarCode.Execute();
            // PayDetailPayment.Execute();
            // PayListPayments.Execute();

        }
    }
}
