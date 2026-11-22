using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasData(
                new Manager
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@nationalbank.com",
                    PhoneNumber = "01012345678",
                    HireDate = new DateTime(2020, 1, 15),
                    BranchCode = "CAI-01"
                },
                new Manager
                {
                    Id = 2,
                    FullName = "Mohamed Ali",
                    Email = "mohamed@nationalbank.com",
                    PhoneNumber = "01112345678",
                    HireDate = new DateTime(2021, 5, 10),
                    BranchCode = "ALX-01"
                }
            );
        }
    }
}
