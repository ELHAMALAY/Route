using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Services
{
    public partial class CustomerService
    {
        private DateTime GetDateOfBirth()
        {
            DateTime dateOfBirth;

            while (true)
            {
                Console.Write("Enter Date of Birth (yyyy-MM-dd): ");

                string input = Console.ReadLine() ?? "";

                bool isValidDate = DateTime.TryParse(
                    input,
                    out dateOfBirth);

                if (isValidDate && dateOfBirth.Date <= DateTime.Today)
                {
                    return dateOfBirth;
                }

                Console.WriteLine("Invalid date! Please enter a valid date.");
            }
        }

        private string GetNationalId()
        {
            while (true)
            {
                Console.Write("Enter National ID: ");

                string nationalId = Console.ReadLine() ?? "";

                if (nationalId.Length == 14 && nationalId.All(char.IsDigit))
                {
                    return nationalId;
                }

                Console.WriteLine("National ID must contain exactly 14 digits.");
            }
        }

        private string GetEmail()
        {
            while (true)
            {
                Console.Write("Enter Email: ");

                string email = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(email) &&
                    email.Contains('@') &&
                    email.Contains('.'))
                {
                    return email;
                }

                Console.WriteLine("Invalid Email! Please enter a valid email.");
            }
        }


        private string GetPhoneNumber()
        {
            while (true)
            {
                Console.Write("Enter Phone Number: ");

                string phoneNumber = Console.ReadLine() ?? "";

                if (phoneNumber.Length == 11 &&
                    phoneNumber.StartsWith("01") &&
                    phoneNumber.All(char.IsDigit))
                {
                    return phoneNumber;
                }

                Console.WriteLine("Invalid Phone Number! Enter an Egyptian mobile number.");
            }
        }


        private string GetAddress()
        {
            while (true)
            {
                Console.Write("Enter Address: ");

                string address = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(address))
                {
                    return address;
                }

                Console.WriteLine("Address cannot be empty!");
            }
        }
    }
}
