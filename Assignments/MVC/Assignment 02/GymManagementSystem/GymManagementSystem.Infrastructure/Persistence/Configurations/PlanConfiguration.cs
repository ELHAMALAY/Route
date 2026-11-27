using GymManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Infrastructure.Persistence.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.Price)
                   .HasPrecision(18, 2);

            builder.ToTable(t => t.HasCheckConstraint("CK_Plan_DurationDays", "DurationDays >= 1 AND DurationDays <= 365"));
        }
    }
}
