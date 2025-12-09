using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLibrary.Transactions
{
    internal interface ITransaction
    {
        void Process();

        int Amount { get; }
        string Status { get; }
        DateTime TransactionDate { get; }
    }
}
