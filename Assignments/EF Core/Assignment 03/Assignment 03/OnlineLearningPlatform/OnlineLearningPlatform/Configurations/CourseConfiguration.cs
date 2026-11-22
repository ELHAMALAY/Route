using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLearningPlatform.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

            builder.Property(c => c.Price)
                   .HasPrecision(10, 2);

            builder.Property(c => c.Level)
                   .IsRequired();

            builder.Property(c => c.IsPublished)
                   .IsRequired();

            builder.Property(c => c.PublishedDate)
                   .IsRequired(false);

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn C# basics",
                    Price = 500,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 1, 10),
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "ASP.NET Core Web API",
                    Description = "Build Web APIs using .NET",
                    Price = 900,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 2, 15),
                    InstructorId = 1,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 3,
                    Title = "Advanced C#",
                    Description = "Advanced C# concepts",
                    Price = 700,
                    Level = CourseLevel.Advanced,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 3, 1),
                    InstructorId = 2,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 4,
                    Title = "HTML and CSS",
                    Description = "Frontend fundamentals",
                    Price = 400,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 4, 5),
                    InstructorId = 2,
                    CategoryId = 2
                },
                new Course
                {
                    Id = 5,
                    Title = "Machine Learning Basics",
                    Description = "Introduction to ML",
                    Price = 1000,
                    Level = CourseLevel.Beginner,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 5
                },
                new Course
                {
                    Id = 6,
                    Title = "Data Science with Python",
                    Description = "Learn data analysis",
                    Price = 850,
                    Level = CourseLevel.Intermediate,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 4
                }
            );
        }
    }
}
