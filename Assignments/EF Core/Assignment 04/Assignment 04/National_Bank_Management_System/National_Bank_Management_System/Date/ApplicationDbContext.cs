using Microsoft.EntityFrameworkCore;
using National_Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Date
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }

    }
}
