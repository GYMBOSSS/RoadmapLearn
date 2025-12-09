using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLibrary.AccountModels
{
    internal class CheckingAccount : BankAccount
    {
        public int Debt { get; private set; } = 0;

        public CheckingAccount(int number, string owner) : base(number, owner) 
        { }
        public CheckingAccount(int number, string owner, int balance) : base(number, owner, balance)
        { }

        public override void Deposit(int summ)
        {
            if (Debt > 0) 
            {
                if (summ <= Debt)
                {
                    Debt -= summ;
                }
                else 
                {
                    int temp = summ - Debt;
                    Debt = 0;
                    Balance += temp;
                }
            }
            else
            {
                Balance += summ;
            }
        }
        public override void Withdraw(int summ)
        {
            int t = 0;
            if (summ > Balance) 
            {
                Debt += summ - Balance;
                Balance = 0;
            }
            else 
            {
                Balance -= summ;
            }
        }
        public override void TransferMoneyTo(BankAccount recipient, int count)
        {
            if (Balance >= count)
            {
                Balance -= count;
                recipient.Balance += count;
            }
            else
            {
                Debt += count - Balance;
                recipient.Balance += count;
                Balance = 0;
            }
        }
    }
}
