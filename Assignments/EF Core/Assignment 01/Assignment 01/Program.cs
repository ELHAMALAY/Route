using Assignment_01.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>()
                .UseSqlServer("Server=localhost;Database=BookStoreDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using var context = new BookStoreContext(options);

            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connected to BookStoreDB Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to connect to Database!");
            }   
        }
    }
}
