
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using System;
using System.Linq;

namespace OnlineLearningPlatform.Operations
{
    public class CategoryOperations
    {
        public static void AddCategory(ApplicationDbContext context)
        {
            var category = new Category
            {
                Name = "Software Engineering",
                Description = "Software Engineering Courses",
                ParentCategoryId = null
            };

            context.Categories.Add(category);
            context.SaveChanges();

            Console.WriteLine("Category added successfully.");
        }

        public static void GetAllCategories(ApplicationDbContext context)
        {
            var categories = context.Categories.ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}, Parent ID: {category.ParentCategoryId}");
            }
        }

        public static void UpdateCategory(
            ApplicationDbContext context,
            int categoryId,
            string newName)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                category.Name = newName;

                context.SaveChanges();

                Console.WriteLine("Category updated successfully.");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }

        public static void DeleteCategory(ApplicationDbContext context, int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                bool hasSubCategories = context.Categories
                    .Any(c => c.ParentCategoryId == categoryId);

                if (hasSubCategories)
                {
                    Console.WriteLine(
                        "Cannot delete this category because it has subcategories.");
                    return;
                }

                context.Categories.Remove(category);
                context.SaveChanges();

                Console.WriteLine("Category deleted successfully.");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }

        public static void GetSubCategories(ApplicationDbContext context, int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            var subCategories = context.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToList();

            Console.WriteLine($"Sub-categories of {category.Name}:");

            if (subCategories.Count == 0)
            {
                Console.WriteLine("No sub-categories found.");
            }

            foreach (var subCategory in subCategories)
            {
                Console.WriteLine(subCategory.Name);
            }
        }

        public static void GetTopLevelCategories(ApplicationDbContext context)
        {
            var categories = context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            Console.WriteLine("Top-level Categories:");

            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }


        public static void TryDeleteCategory(ApplicationDbContext context, int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();

                Console.WriteLine("Category deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(
                    $"Cannot delete category: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public static void SafeDeleteCategory(ApplicationDbContext context, int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            try
            {
                var hasSubCategories = context.Categories
                    .Any(c => c.ParentCategoryId == categoryId);

                if (hasSubCategories)
                {
                    Console.WriteLine("Cannot delete category because it has subcategories.");
                    return;
                }
                context.Categories.Remove(category);
                context.SaveChanges();

                Console.WriteLine("Category deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                context.Entry(category).State = EntityState.Unchanged;
                Console.WriteLine($"Cannot delete category: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

    }
}
