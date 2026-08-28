using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    internal class Exercise3 : IExercise
    {
        public void Run()
        {
            //1.
            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                {"Ahmed" , "01012345678"},
                { "Sara", "01123456789" },
                { "Ali", "01234567890" },
                { "Mona", "01534567890" }
            };

            //2.
            phoneBook["Youssef"] = "01098765432";

            //3.
            try
            {
                phoneBook.Add("Ahmed", "01111111111");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Add Error: {ex.Message}");
            }

            //4.
            bool added = phoneBook.TryAdd("Ahmed", "01222222222");
            Console.WriteLine($"\nTryAdd succeeded: {added}");

            //5.
            bool contactExists = phoneBook.ContainsKey("Khaled");
            Console.WriteLine($"Khaled exists: {contactExists}");

            //6.
            string phoneNumber = phoneBook.GetValueOrDefault("Khaled", "Not Found");
            Console.WriteLine($"Khaled phone number: {phoneNumber}");

            //7.
            Console.Write("Keys: ");
            Console.WriteLine(string.Join(", ", phoneBook.Keys));

            Console.Write("Values: ");
            Console.WriteLine(string.Join(", ", phoneBook.Values));
        }
    }
}
