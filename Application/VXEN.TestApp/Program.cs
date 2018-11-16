using System;
using VXEN.Models.Transaction;
using VXEN.Services;
using VXEN.TestApp.Tests;

namespace VXEN.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create the session singleton
            Session session = Session.Instance;

            // Create an application and bind it to the session
            var application = new typeApplication();
            application.ApplicationID = Settings.ApplicationID;
            application.ApplicationName = "VXEN.TestApp";
            application.ApplicationVersion = "1.0.0";
            session.ConfigureApplication(application);

            // Create a credentials instance and bind it to the session
            var credentials = new typeCredentials();
            credentials.AcceptorID = Settings.AcceptorID;
            credentials.AccountID = Settings.AccountID;
            credentials.AccountToken = Settings.AccountToken;
            session.ConfigureCredentials(credentials);

            // Create a terminal instance and bind it to the session
            var terminal = new typeTerminal();
            terminal.TerminalID = Environment.MachineName;
            terminal.CardPresentCode = "3";
            terminal.CardholderPresentCode = "4";
            terminal.CardInputCode = "4";
            terminal.CVVPresenceCode = "2";
            terminal.TerminalCapabilityCode = "2";
            terminal.TerminalEnvironmentCode = "6";
            terminal.MotoECICode = "7";
            session.ConfigureTerminal(terminal);

            // Bind the API URL to the session
            session.ConfigureUri(Settings.apiURL);

            // Perform some tests
            Test.CheckSaleTest();
            Test.CreditCardSale();

            Console.WriteLine("Press Any Key To Exit");
            Console.Read();
        }
    }
}
