using Microsoft.EntityFrameworkCore;
using National_Bank_Management_System.Date;
using National_Bank_Management_System.Enums;
using National_Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Services
{
    public partial class CustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCustomer()
        {
            Console.Write("Enter Full Name: ");
            string fullName;

            while(true)
            {
                fullName = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    break;
                }

                Console.WriteLine("Full Name cannot be empty!");
            }

            Console.Write("Enter National ID: ");
            string nationalId = GetNationalId();

            Console.Write("Enter Date of Birth: ");
            DateTime dateOfBirth = GetDateOfBirth();

            Console.Write("Enter Email: ");
            string email = GetEmail();

            Console.Write("Enter Phone Number: ");
            string phoneNumber = GetPhoneNumber();

            Console.Write("Enter Address: ");
            string address = GetAddress();

            CustomerType customerType;

            while(true)
            {
                Console.WriteLine("Choose Customer Type:");
                Console.WriteLine("1. Individual");
                Console.WriteLine("2. Business");
                Console.Write("Enter choice: ");

                string typeChoice = Console.ReadLine() ?? "";

                if (typeChoice == "1")
                {
                    customerType = CustomerType.Individual;
                    break;
                }
                else if (typeChoice == "2")
                {
                    customerType = CustomerType.Business;
                    break;
                }

                Console.WriteLine("Invalid choice! Please choose 1 or 2.");
            }

            Customer customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                CustomerType = customerType
            };

            _context.Customers.Add(customer);

            _context.SaveChanges();

            Console.WriteLine("Customer added successfully!");
        }


        public void OpenAccount()
        {
            string accountNumber = GetAccountNumber();

            AccountType accountType = GetAccountType();

            string branchCode = GetBranchCode();

            int customerId = GetCustomerId();

            OwnershipType ownershipType = GetOwnershipType();

            Account account = new Account
            {
                AccountNumber = accountNumber,
                CurrentBalance = 0,
                AccountType = accountType,
                OpeningDate = DateTime.Today,
                BranchCode = branchCode
            };

            CustomerAccount customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipType = ownershipType,
                OwnershipStartDate = DateTime.Today
            };

            customerAccount.AccountStatus = AccountStatus.Active;

            _context.Accounts.Add(account);

            _context.CustomerAccounts.Add(customerAccount);

            _context.SaveChanges();

            Console.WriteLine("Account opened successfully!");
        }


        public void UpdateAccountStatus()
        {
            string accountNumber = GetExistingAccountNumber();

            int customerId = GetCustomerId();

            CustomerAccount? customerAccount = _context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.AccountNumber == accountNumber &&
                    ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine("This customer does not own this account!");
                return;
            }

            if (customerAccount.AccountStatus == AccountStatus.Active)
            {
                customerAccount.AccountStatus = AccountStatus.Closed;
            }
            else
            {
                customerAccount.AccountStatus = AccountStatus.Active;
            }

            _context.SaveChanges();

            Console.WriteLine("Account status updated successfully!");
        }


        public void RemoveAccountFromCustomer()
        {
            string accountNumber = GetExistingAccountNumber();

            int customerId = GetCustomerId();

            CustomerAccount? customerAccount = _context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.AccountNumber == accountNumber &&
                    ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine("This customer does not own this account!");
                return;
            }

            _context.CustomerAccounts.Remove(customerAccount);

            _context.SaveChanges();

            Console.WriteLine("Account removed from customer successfully!");
        }


        public void ListCustomersWithAccounts()
        {
            var customers = _context.Customers
                .Include(c => c.CustomerAccounts)
                    .ThenInclude(ca => ca.Account)
                        .ThenInclude(a => a.Branch)
                .ToList();

            Console.WriteLine("\n--- All Customers ---");

            int customerNumber = 1;

            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"#{customerNumber} {customer.FullName} ({customer.CustomerType})");

                if (customer.CustomerAccounts.Count == 0)
                {
                    Console.WriteLine("(no accounts)");
                }

                foreach (var customerAccount in customer.CustomerAccounts)
                {
                    var account = customerAccount.Account;

                    Console.WriteLine(
                        $"{account.AccountNumber}  Current Balance: {account.CurrentBalance:N2}  " +
                        $"{customerAccount.OwnershipType}  {customerAccount.AccountStatus}  " +
                        $"@ {account.Branch.Name}");
                }

                customerNumber++;
            }
        }
    }
}
