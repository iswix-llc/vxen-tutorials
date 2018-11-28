using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VXEN.Models.Transaction;
using VXEN.Services;

namespace TestApp.Transaction
{
    public partial class TransactionSamples
    {
        public static void ProcessCreditCardSale()
        {
            var creditCardSale = new typeCreditCardSale();
            creditCardSale.Application = Session.Instance.GetApplication<typeApplication>();
            creditCardSale.Credentials = Session.Instance.GetCredentials<typeCredentials>();
            creditCardSale.Terminal = Session.Instance.GetTerminal();
            creditCardSale.Transaction = new typeTransaction()
            {
                TransactionAmount = 100m,
                TransactionAmountSpecified = true,
                ReferenceNumber = "REDATED"
            };

            string testCreditCardPrefix = "549999012345";
            string testCreditCardSuffix = "6781";
            creditCardSale.Card = new typeCard()
            {
                CardNumber = testCreditCardPrefix + testCreditCardSuffix,
                ExpirationMonth = "MM",
                ExpirationYear = "YY"
            };

            var task = Server.SendToAPIAsync<typeCreditCardSale>(creditCardSale);
            task.Wait();
            var response = XDocument.Parse(task.Result);
        }
    }
}
