using System;
using System.Collections.Generic;
using System.Text;
using Assignment_01.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_01.Data
{
    internal class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
