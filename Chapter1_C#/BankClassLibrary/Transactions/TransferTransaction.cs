using System;
using System.Collections.Generic;
using System.Text;
using BankClassLibrary.AccountModels;
using Microsoft.Extensions.Logging;

namespace BankClassLibrary.Transactions
{
    internal class TransferTransaction : ITransaction
    {
        private BankAccount _owner { get; set; }
        private BankAccount _recipient { get; set; }
        
        private readonly ILogger logger;

        public int Amount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public TransferTransaction(BankAccount owner, BankAccount recipient, int amount, ILogger logger) 
        {
            _owner = owner;
            _recipient = recipient;
            Amount = amount;
            this.logger = logger;
        }


        public void Process()
        {
            if (_owner == null || _recipient == null)
            {
                Console.WriteLine("Один из участников транзакции не найден");
                Status = "Aborted";
                logger.LogInformation("Transfer transaction is aborted");
            }
            else
            {
                _owner.TransferMoneyTo(_recipient, Amount);
                Status = "Success";
                logger.LogInformation($"Transfer transaction is completed. Transfered: {Amount}");
            }
        }
    }
}
