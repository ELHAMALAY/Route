
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using National_Bank_Management_System.Data;
using National_Bank_Management_System.Date;

namespace National_Bank_Management_System.Data
{
    public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
