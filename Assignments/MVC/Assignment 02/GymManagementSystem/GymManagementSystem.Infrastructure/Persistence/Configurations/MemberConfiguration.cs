using GymManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Infrastructure.Persistence.Configurations
{
    public class MemberConfiguration : GymUserConfiguration<Member>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.JoinDate)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
