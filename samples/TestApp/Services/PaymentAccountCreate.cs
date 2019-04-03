using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VXEN.Models.Services;
using VXEN.Services;

namespace TestApp.Services
{
    public partial class ServicesSamples
    {
        public static void PaymentAccountCreate()
        {
            typePaymentAccountCreateWithTransID paymentAccountCreateWithTransID = new typePaymentAccountCreateWithTransID();
            typeCard card = new typeCard();
            card.CardNumber = "12345678";
            card.WalletType = typeCardWalletType.Item2;

            typePaymentAccount paymentAccount = new typePaymentAccount();
            paymentAccount.PaymentAccountType = "0";

            paymentAccountCreateWithTransID.Application = Session.Instance.GetApplication<typeApplication>();
            paymentAccountCreateWithTransID.Credentials = Session.Instance.GetCredentials<typeCredentials>();
            paymentAccountCreateWithTransID.PaymentAccount = paymentAccount;
            paymentAccountCreateWithTransID.Card = card;

            var xml = Serialization.Serialize<typePaymentAccountCreateWithTransID>(paymentAccountCreateWithTransID);
            Console.WriteLine("PAK");
        }
    }
}
