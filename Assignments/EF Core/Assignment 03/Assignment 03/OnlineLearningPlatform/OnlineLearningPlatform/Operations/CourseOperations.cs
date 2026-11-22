
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using System;
using System.Linq;

namespace OnlineLearningPlatform.Operations
{
    public class CourseOperations
    {
        public static void AddCourse(ApplicationDbContext context)
        {
            int instructorId = context.Instructors
                .OrderByDescending(i => i.Id)
                .Select(i => i.Id)
                .FirstOrDefault();

            int categoryId = 2;

            var instructor = context.Instructors
                .FirstOrDefault(i => i.Id == instructorId);

            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (instructor == null)
            {
                Console.WriteLine("Instructor not found.");
                return;
            }

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
            var course = new Course
            {
                Title = "C# Advanced",
                Description = "Advanced C# Programming",
                Price = 500,
                Level = CourseLevel.Advanced,
                IsPublished = false,
                InstructorId = 1,
                CategoryId = 1
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine("Course added successfully.");
        }

        public static void GetAllCourses(ApplicationDbContext context)
        {
            var courses = context.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"ID: {course.Id}, Title: {course.Title}, Price: {course.Price}, Level: {course.Level}, Published: {course.IsPublished}");
            }
        }

        public static void UpdateCourse(
            ApplicationDbContext context,
            int courseId,
            string newTitle,
            decimal newPrice)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                course.Title = newTitle;
                course.Price = newPrice;

                context.SaveChanges();

                Console.WriteLine("Course updated successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }


        public static void DeleteCourse(ApplicationDbContext context, int courseId)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            int enrollmentsBefore = context.Enrollments
                .Count(e => e.CourseId == courseId);

            context.Courses.Remove(course);
            context.SaveChanges();

            int enrollmentsAfter = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments before deletion: {enrollmentsBefore}");
            Console.WriteLine($"Enrollments after deletion: {enrollmentsAfter}");

            // Related enrollments are deleted automatically because of Cascade Delete.
            Console.WriteLine("Course deleted successfully.");
        }


        public static void FindCourseById(ApplicationDbContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course != null)
            {
                Console.WriteLine($"ID: {course.Id}, Title: {course.Title}, Price: {course.Price}, Level: {course.Level}, Published: {course.IsPublished}");
            }
            else
            {
                Console.WriteLine("Course not found.");
                return;
            }
        }

        public static void FindCourseByTitle(ApplicationDbContext context, string title)
        {
            var course = context.Courses.FirstOrDefault(c => c.Title == title);

            if(course != null)
            {
                Console.WriteLine($"ID: {course.Id}, Title: {course.Title}, Price: {course.Price}, Level: {course.Level}, Published: {course.IsPublished}");
            }
            else
            {
                Console.WriteLine("Course not found.");
                return;
            }
        }

        public static void FilterCourses(ApplicationDbContext context, decimal minPrice, decimal maxPrice)
        {
            var courses = context.Courses
                .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .ToList();

            if(courses.Count == 0)
            {
                Console.WriteLine("No courses found within the specified price range.");
            }
            else
            {
                foreach (var course in courses)
                {
                    Console.WriteLine($"ID: {course.Id}, Title: {course.Title}, Price: {course.Price}, Level: {course.Level}, Price: {course.Price}");
                }
            }
        }

        public static void GetCourseRoster(ApplicationDbContext context, int courseId)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            var studentsIds = context.Enrollments
                .Where(e => courseId == e.CourseId)
                .Select(e => e.StudentId)
                .ToList();

            var students = context.Students
                .Where(s => studentsIds.Contains(s.Id))
                .ToList();

            Console.WriteLine($"Course: {course.Title}");
            Console.WriteLine($"Number of enrolled students: {students.Count}");

            foreach (var student in students)
            {
                Console.WriteLine(student.FullName);
            }
        }


        public static void PublishCourse(ApplicationDbContext context, int courseId)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            if (course.IsPublished)
            {
                Console.WriteLine("Course is already published.");
                return;
            }

            course.IsPublished = true;
            course.PublishedDate = DateTime.Now;

            context.SaveChanges();

            Console.WriteLine("Course published successfully.");
        }

        public static void ChangeCoursePrice(ApplicationDbContext context, int courseId, decimal newPrice)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.Price = newPrice;

            context.SaveChanges();

            Console.WriteLine("Course price updated successfully.");
        }

        public static void IncreasePublishedCoursesPrices(ApplicationDbContext context,CourseLevel level)
        {
            int affectedRows = context.Courses
                .Where(c => c.IsPublished && c.Level == level)
                .ExecuteUpdate(setters => setters
                    .SetProperty(c => c.Price, c => c.Price * 1.10m));

            Console.WriteLine($"Affected courses: {affectedRows}");
        }

    }
}
