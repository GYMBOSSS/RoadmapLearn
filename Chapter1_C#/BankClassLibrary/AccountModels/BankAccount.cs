using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLibrary.AccountModels
{
    public abstract class BankAccount
    {
        public int Number {  get; set; }
        public string Owner { get; set; }
        public int Balance { get; internal set; }

        public BankAccount(int number, string owner) 
        {
            Number = number;
            Owner = owner;
            Balance = 0;
        }
        public BankAccount(int number, string owner, int balance)
        {
            Number = number;
            Owner = owner;
            Balance = balance;
        }

        public virtual void Deposit(int summ) 
        {
            Balance += summ;
        }
        public virtual void Withdraw(int summ) 
        {
            if (Balance >= summ)
            {
                Balance -= summ;
            }
            else 
            {
                Console.WriteLine("Недостаточно средств на балансе");
            }
        }
        public virtual void TransferMoneyTo(BankAccount recipient, int count) 
        {
            if (Balance >= count) 
            {
                Balance -= count;
                recipient.Balance += count;
            }
            else 
            {
                Console.WriteLine("У держателя недостаточно средств для перевода");
            }
        }
    }
}
