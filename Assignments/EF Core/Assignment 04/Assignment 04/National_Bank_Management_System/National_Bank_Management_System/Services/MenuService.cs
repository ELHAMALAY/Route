using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Services
{
    public class MenuService
    {
        private readonly CustomerService _customerService;

        public MenuService(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine("    National Bank - Management");
            Console.WriteLine("==================================");

            Console.WriteLine("1) Add a new Customer");
            Console.WriteLine("2) Open a new Account for a Customer");
            Console.WriteLine("3) Update Account Status");
            Console.WriteLine("4) Remove an Account from a Customer");
            Console.WriteLine("5) List all Customers (with accounts)");
            Console.WriteLine("0) Exit");

            Console.WriteLine("----------------------------------");
        }

        public string? GetUserChoice()
        {
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            return choice;
        }

        public void HandleChoice(string? choice)
        {
            switch (choice)
            {
                case "1":
                    _customerService.AddCustomer();
                    break;

                case "2":
                    _customerService.OpenAccount();
                    break;

                case "3":
                    _customerService.UpdateAccountStatus();
                    break;

                case "4":
                    _customerService.RemoveAccountFromCustomer();
                    break;

                case "5":
                    _customerService.ListCustomersWithAccounts();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
         }

        public void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ShowMenu();

                string? choice = GetUserChoice();

                if (choice == "0")
                {
                    isRunning = false;
                }
                else
                {
                    HandleChoice(choice);

                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        
    }
}
