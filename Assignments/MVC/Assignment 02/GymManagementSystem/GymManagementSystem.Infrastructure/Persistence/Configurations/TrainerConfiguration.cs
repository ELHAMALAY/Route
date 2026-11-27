using GymManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Infrastructure.Persistence.Configurations
{
    public class TrainerConfiguration : GymUserConfiguration<Trainer>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.HireDate)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
