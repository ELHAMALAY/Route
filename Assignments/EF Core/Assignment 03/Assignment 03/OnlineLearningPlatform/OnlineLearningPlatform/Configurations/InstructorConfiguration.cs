using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Configurations
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(i => i.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(i => i.Bio)
                   .HasMaxLength(500);

            builder.Property(i => i.JoinedDate)
                   .IsRequired();

            builder.HasMany(i => i.Courses)
                   .WithOne(c => c.Instructor)
                   .HasForeignKey(c => c.InstructorId);

            builder.HasData(
                new Instructor
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@example.com",
                    Bio = "Backend .NET Developer",
                    JoinedDate = new DateTime(2024, 1, 10)
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Omar Ali",
                    Email = "omar@example.com",
                    Bio = "Frontend Developer",
                    JoinedDate = new DateTime(2023, 6, 15)
                },
                new Instructor
                {
                    Id = 3,
                    FullName = "Sara Hassan",
                    Email = "sara@example.com",
                    Bio = null,
                    JoinedDate = new DateTime(2024, 3, 20)
                }
            );
        }
    }
}
