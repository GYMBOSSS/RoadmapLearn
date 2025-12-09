using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLibrary.AccountModels
{
    internal class SavingAccount : BankAccount
    {
        public int YearPercent { get; private set; }

        public SavingAccount(int number, string owner) : base(number, owner)
        { }
        public SavingAccount(int number, string owner, int balance) : base(number, owner, balance)
        { }

        public void MonthIncrease() 
        {
            Balance *= (1 + YearPercent / 100);
        }
    }
}
