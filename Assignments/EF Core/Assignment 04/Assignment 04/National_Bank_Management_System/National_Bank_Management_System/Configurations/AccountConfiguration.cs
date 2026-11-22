using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace National_Bank_Management_System.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);

            builder.HasOne(a => a.Branch)
                   .WithMany(b => b.Accounts)
                   .HasForeignKey(a => a.BranchCode)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
