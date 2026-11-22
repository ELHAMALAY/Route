using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLearningPlatform.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);


            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Courses)
                   .WithOne(c => c.Category)
                   .HasForeignKey(c => c.CategoryId);

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Web Development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Backend Development",
                    ParentCategoryId = 2
                },
                new Category
                {
                    Id = 4,
                    Name = "Data Science",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = 5,
                    Name = "Machine Learning",
                    ParentCategoryId = 4
                }
            );
        }
    }
}
