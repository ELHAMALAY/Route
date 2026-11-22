using National_Bank_Management_System.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Services
{
    public partial class CustomerService
    {
        private string GetAccountNumber()
        {
            while (true)
            {
                Console.Write("Enter Account Number: ");

                string accountNumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    Console.WriteLine("Account Number cannot be empty!");
                    continue;
                }

                bool accountExists = _context.Accounts.Any(a => a.AccountNumber == accountNumber);

                if (accountExists)
                {
                    Console.WriteLine("This Account Number already exists!");
                    continue;
                }

                return accountNumber;
            }
        }



        private AccountType GetAccountType()
        {
            while (true)
            {
                Console.WriteLine("Choose Account Type:");
                Console.WriteLine("1. Savings");
                Console.WriteLine("2. Current");
                Console.WriteLine("3. Business");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                if (choice == "1")
                {
                    return AccountType.Savings;
                }
                else if (choice == "2")
                {
                    return AccountType.Current;
                }
                else if (choice == "3")
                {
                    return AccountType.Business;
                }

                Console.WriteLine("Invalid choice! Please choose 1, 2, or 3.");
            }
        }


        private OwnershipType GetOwnershipType()
        {
            while (true)
            {
                Console.WriteLine("Choose Ownership Type:");
                Console.WriteLine("1. Primary");
                Console.WriteLine("2. CoHolder");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                if (choice == "1")
                {
                    return OwnershipType.Primary;
                }
                else if (choice == "2")
                {
                    return OwnershipType.CoHolder;
                }

                Console.WriteLine("Invalid choice! Please choose 1 or 2.");
            }
        }

        private string GetBranchCode()
        {
            while (true)
            {
                Console.Write("Enter Branch Code: ");

                string branchCode = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(branchCode))
                {
                    Console.WriteLine("Branch Code cannot be empty!");
                    continue;
                }

                bool branchExists = _context.Branches.Any(b => b.Code == branchCode);

                if (!branchExists)
                {
                    Console.WriteLine("Branch does not exist!");
                    continue;
                }

                return branchCode;
            }
        }



        private int GetCustomerId()
        {
            while (true)
            {
                Console.Write("Enter Customer ID: ");

                string input = Console.ReadLine() ?? "";

                bool isValid = int.TryParse(input, out int customerId);

                if (!isValid || customerId <= 0)
                {
                    Console.WriteLine("Invalid Customer ID!");
                    continue;
                }

                bool customerExists = _context.Customers
                    .Any(c => c.Id == customerId);

                if (customerExists)
                {
                    return customerId;
                }

                Console.WriteLine("Customer does not exist!");
            }
        }


        private string GetExistingAccountNumber()
        {
            while (true)
            {
                Console.Write("Enter Account Number: ");

                string accountNumber = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    Console.WriteLine("Account Number cannot be empty!");
                    continue;
                }

                bool accountExists = _context.Accounts
                    .Any(a => a.AccountNumber == accountNumber);

                if (accountExists)
                {
                    return accountNumber;
                }

                Console.WriteLine("Account does not exist!");
            }
        }
    }
}
