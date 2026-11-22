using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);

            builder.HasOne(b => b.Manager)
                   .WithOne(m => m.Branch)
                   .HasForeignKey<Manager>(m => m.BranchCode)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                 new Branch
                 {
                     Code = "CAI-01",
                     Name = "Cairo Main Branch",
                     Address = "Cairo, Egypt",
                     PhoneNumber = "0223456789"
                 },
                new Branch
                {
                    Code = "ALX-01",
                    Name = "Alexandria Branch",
                    Address = "Alexandria, Egypt",
                    PhoneNumber = "0334567890"
                }
             );
        }
    }
}
