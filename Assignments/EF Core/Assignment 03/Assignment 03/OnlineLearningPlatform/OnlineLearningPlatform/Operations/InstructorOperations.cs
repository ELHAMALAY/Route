
using System;
using System.Linq;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Operations
{
    public class InstructorOperations
    {
        public static void AddInstructor(ApplicationDbContext context)
        {
            var instructor = new Instructor
            {
                FullName = "Mohamed Hassan",
                Email = "mohamed.hassan@example.com",
                Bio = "Backend .NET Instructor",
                JoinedDate = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            Console.WriteLine($"Instructor added successfully. ID: {instructor.Id}");
        }

        public static void GetAllInstructors(ApplicationDbContext context)
        {
            var instructors = context.Instructors.ToList();

            foreach (var instructor in instructors)
            {
                Console.WriteLine( $"ID: {instructor.Id}, Name: {instructor.FullName}, Email: {instructor.Email}");
            }
        }

        public static void UpdateInstructor(ApplicationDbContext context, int instructorId, string newName, string newEmail)
        {
            var instructor = context.Instructors
                .FirstOrDefault(i => i.Id == instructorId);

            if (instructor != null)
            {
                instructor.FullName = newName;
                instructor.Email = newEmail;

                context.SaveChanges();

                Console.WriteLine("Instructor updated successfully.");
            }
            else
            {
                Console.WriteLine("Instructor not found.");
            }
        }

        public static void DeleteInstructor(ApplicationDbContext context, int instructorId)
        {
            var instructor = context.Instructors
                .FirstOrDefault(i => i.Id == instructorId);

            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
                context.SaveChanges();

                Console.WriteLine("Instructor deleted successfully.");
            }
            else
            {
                Console.WriteLine("Instructor not found.");
            }
        }
    }
}
