using System;
using System.Transactions;

namespace AmbientTransactionsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TxSample1();
        }

        private static void TxSample1()
        {
            using (var scope = new TransactionScope())
            {
                ShowTxInfo("started", Transaction.Current.TransactionInformation);
                Transaction.Current.TransactionCompleted += Current_TransactionCompleted;

                TxSample2();

                scope.Complete();  // happy bit
            }
        }

        private static void TxSample2()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                ShowTxInfo("inner", Transaction.Current.TransactionInformation);

                // scope.Complete();
            }
        }

        private static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
        {
            ShowTxInfo("completed", e.Transaction.TransactionInformation);
        }

        private static void ShowTxInfo(string title, TransactionInformation txInfo)
        {
            Console.WriteLine(title);
            Console.WriteLine(txInfo.Status);
            Console.WriteLine(txInfo.CreationTime);
            Console.WriteLine(txInfo.LocalIdentifier);
            Console.WriteLine(txInfo.DistributedIdentifier);
            Console.WriteLine();
        }
    }
}
