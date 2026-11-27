using GymManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Infrastructure.Persistence.Configurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>

    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Ignore(m => m.IsActive);

            builder.Property(m => m.StartDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.Member)
                   .WithMany(mem => mem.Memberships)
                   .HasForeignKey(m => m.MemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Plan)
                   .WithMany(p => p.Memberships)
                   .HasForeignKey(m => m.PlanId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
