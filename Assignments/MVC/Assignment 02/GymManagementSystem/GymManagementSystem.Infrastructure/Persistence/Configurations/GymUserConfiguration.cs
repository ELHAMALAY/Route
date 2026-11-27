using GymManagementSystem.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Infrastructure.Persistence.Configurations
{
    public class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.Property(u => u.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

            builder.Property(u => u.Email)
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

            builder.Property(u => u.Phone)
                    .HasColumnType("varchar")
                    .HasMaxLength(11);
            builder.HasIndex(u => u.Phone).IsUnique();

            builder.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.Street).HasColumnType("varchar").HasMaxLength(50);
                address.Property(a => a.City).HasColumnType("varchar").HasMaxLength(50);
                address.Property(a => a.BuildingNumber).HasColumnType("varchar").HasMaxLength(10);
            });
        }
    }
}
