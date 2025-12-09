using BankClassLibrary.AccountModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace BankClassLibrary.Transactions
{
    internal class WithdrawTransaction : ITransaction
    {
        private readonly BankAccount _account;
        private readonly ILogger logger;

        public int Amount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public WithdrawTransaction(BankAccount account, int amount, ILogger logger) 
        {
            _account = account;
            Amount = amount;
            this.logger = logger;
        }

        public void Process()
        {
            try 
            {
                _account.Withdraw(Amount);
                Status = "Success";
            }
            catch(Exception ex) 
            {
                logger.LogInformation(ex.Message);
            }
        }
    }
}
