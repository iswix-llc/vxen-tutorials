using System;
using VXEN.Models.Transaction;
using VXEN.Services;

namespace TestApp.Common
{
    public class Utility
    {
        /// <summary>
        /// http://www.elementps.com/Create-a-Test-Account
        /// </summary>
        public static void ConfigureInstance()
        {
            Session.Instance.APILifeCycle = APILifeCycle.Certification;
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
    }
}
