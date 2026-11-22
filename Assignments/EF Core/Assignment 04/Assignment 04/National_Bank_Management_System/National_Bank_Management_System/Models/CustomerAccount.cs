using System;
using System.Collections.Generic;
using System.Text;
using National_Bank_Management_System.Enums;


namespace National_Bank_Management_System.Models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }

        public string AccountNumber { get; set; } = null!;

        public OwnershipType OwnershipType { get; set; }

        public DateTime OwnershipStartDate { get; set; }

        public AccountStatus AccountStatus { get; set; }

        public Customer Customer { get; set; } = null!;

        public Account Account { get; set; } = null!;
    }
}
