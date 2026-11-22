using System;
using System.Collections.Generic;
using System.Text;
using National_Bank_Management_System.Enums;

namespace National_Bank_Management_System.Models
{
    public class Transaction
    {
        public int TransactionNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string? Note { get; set; }

        public TransactionType TransactionType { get; set; }

        public string AccountNumber { get; set; } = null!;

        public Account Account { get; set; } = null!;
    }
}
