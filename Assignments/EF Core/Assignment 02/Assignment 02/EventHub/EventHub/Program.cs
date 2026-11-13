using EventHub.Data;
using Microsoft.EntityFrameworkCore;

namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                @"Server=localhost;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<EventHubDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new EventHubDbContext(options);
        }
    }
}
