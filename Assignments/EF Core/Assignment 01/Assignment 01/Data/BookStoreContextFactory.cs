using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Assignment_01.Data
{
    internal class BookStoreContextFactory : IDesignTimeDbContextFactory<BookStoreContext>
    {
        public BookStoreContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>()
                .UseSqlServer("Server=localhost;Database=BookStoreDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            return new BookStoreContext(options);
        }
    }
}
