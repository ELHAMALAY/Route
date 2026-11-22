using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Models
{
    public class Branch
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public Manager Manager { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = new List<Account>();

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
