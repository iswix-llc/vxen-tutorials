using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VXEN.Models.Transaction;
using VXEN.Services;

namespace vxen_console_testapp
{
    class Program
    {
        /// <summary>
        /// http://www.elementps.com/Create-a-Test-Account
        /// </summary>
        static void Main(string[] args)
        {
            ConfigureInstance();
            XDocument responseDocument = ProcessCreditCardSale();

            string expressResponseCode = responseDocument.GetElementValueFromResponse("ExpressResponseCode");
            string expressResponseMessage = responseDocument.GetElementValueFromResponse("ExpressResponseMessage");
            Console.WriteLine($"{expressResponseCode} : {expressResponseMessage}");
            Console.WriteLine("Full Response:");
            Console.WriteLine(responseDocument.ToString());
            Console.WriteLine("Press Any Key");
            Console.Read();
        }

        static void ConfigureInstance()
        {
            Session.Instance.ConfigureUri("https://certtransaction.elementexpress.com");
            Session.Instance.ConfigureApplication(new typeApplication()
            {
                ApplicationID = "REDACTED",
                ApplicationName = "vxen-console-testapp",
                ApplicationVersion = "1.0.0"
            }
            );
            Session.Instance.ConfigureCredentials(new typeCredentials()
            {
                AccountID = "REDACTED",
                AccountToken = "REDACTED",
                AcceptorID = "REDACTED"
            });
            Session.Instance.ConfigureTerminal(new typeTerminal()
            {
                TerminalID = Environment.MachineName,
                CardPresentCode = "3",
                CardholderPresentCode = "4",
                CardInputCode = "4",
                CVVPresenceCode = "2",
                TerminalCapabilityCode = "2",
                TerminalEnvironmentCode = "6",
                MotoECICode = "7"
            });

        }

        static XDocument ProcessCreditCardSale()
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
            creditCardSale.Card = new typeCard()
            {
                CardNumber = "REDACTED",
                ExpirationMonth = "MM",
                ExpirationYear = "YY"
            };

            var task = Server.SendToAPIAsync<typeCreditCardSale>(creditCardSale);
            task.Wait();

            return XDocument.Parse(task.Result);
        }
    }
}
