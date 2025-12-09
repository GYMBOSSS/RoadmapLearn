using BankClassLibrary.AccountModels;
using BankClassLibrary.Transactions;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankClassLibrary
{
    internal class Bank
    {
        private List<BankAccount> accounts;
        public Bank() { accounts = new List<BankAccount>(); }

        public void CreateCheckingAccount(int number, string owner, int balance) 
        {
            BankAccount account = new CheckingAccount(number, owner, balance);
            accounts.Add(account);
        }
        public void CreateSavingAccount(int number, string owner, int balance) 
        {
            BankAccount account = new SavingAccount(number, owner, balance);
            accounts.Add(account);
        }
        public void UpdateBankAccountOwner(int number, string newOwner) 
        {
            BankAccount? account = accounts.FirstOrDefault(a => a.Number == number);
            account?.Owner = newOwner;
        }
        public BankAccount GetAccountByNumber(int number) { return accounts.FirstOrDefault(a => a.Number == number); }
        
        public void ProcessTransaction(ITransaction transaction) 
        {
            transaction.Process();
        }
    }
}