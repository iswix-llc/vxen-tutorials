using TestApp.Common;
using TestApp.Transaction;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.ConfigureInstance();
            TransactionSamples.ProcessCreditCardSale();

        }
    }
}
