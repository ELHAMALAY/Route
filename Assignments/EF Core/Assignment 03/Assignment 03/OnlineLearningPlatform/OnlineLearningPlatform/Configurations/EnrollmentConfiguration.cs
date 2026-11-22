using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLearningPlatform.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new {e.StudentId, e.CourseId});


            builder.Property(e => e.EnrollmentDate)
                   .IsRequired();

            builder.Property(e => e.Progress)
                   .HasPrecision(5, 2)
                   .IsRequired();

            builder.Property(e => e.Status)
                   .IsRequired();

            builder.Property(e => e.FinalGrade)
                   .HasPrecision(5, 2)
                   .IsRequired(false);

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Enrollments)
                    .HasForeignKey(e => e.StudentId);

            builder.HasOne(e => e.Course)
                  .WithMany()
                  .HasForeignKey(e => e.CourseId);
        }
    }
}
