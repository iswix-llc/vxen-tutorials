using TestApp.Common;
//using TestApp.Transaction;
using TestApp.Services;
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.ConfigureInstance();
            //TransactionSamples.ProcessCreditCardSale();
            ServicesSamples.PaymentAccountCreate();
        }
    }
}
