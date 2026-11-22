using Microsoft.EntityFrameworkCore;
using National_Bank_Management_System.Date;
using National_Bank_Management_System.Services;

namespace National_Bank_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbContextOptions<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(
                        "Server=localhost;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;")
                    .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            CustomerService customerService = new CustomerService(context);

            MenuService menuService = new MenuService(customerService);

            menuService.RunMenu();
        }
    }
}
