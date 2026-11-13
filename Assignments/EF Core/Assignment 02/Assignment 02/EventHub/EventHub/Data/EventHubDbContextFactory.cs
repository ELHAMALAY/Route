using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub.Data
{
    public class EventHubDbContextFactory : IDesignTimeDbContextFactory<EventHubDbContext>
    {
        EventHubDbContext IDesignTimeDbContextFactory<EventHubDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<EventHubDbContext>();

            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new EventHubDbContext(optionsBuilder.Options);
        }
    }
}
