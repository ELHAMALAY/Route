
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using System;
using System.Linq;

namespace OnlineLearningPlatform.Operations
{
    public class EnrollmentOperations
    {
        public static void AddEnrollment(ApplicationDbContext context, int studentId, int courseId)
        {
            var student = context.Students
                .FirstOrDefault(s => s.Id == studentId);

            var course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);

            if (student == null || course == null)
            {
                Console.WriteLine("Student or Course not found.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Cannot enroll in an unpublished course.");
                return;
            }

            bool alreadyEnrolled = context.Enrollments
                .Any(e => e.StudentId == studentId &&
                          e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                Console.WriteLine("Student is already enrolled in this course.");
                return;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                Progress = 0,
                Status = EnrollmentStatus.Active,
                FinalGrade = null
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Enrollment added successfully.");
        }

        public static void GetAllEnrollments(ApplicationDbContext context)
        {
            var enrollments = context.Enrollments.ToList();

            foreach (var enrollment in enrollments)
            {
                Console.WriteLine(
                    $"Student ID: {enrollment.StudentId}, " +
                    $"Course ID: {enrollment.CourseId}, " +
                    $"Progress: {enrollment.Progress}%, " +
                    $"Status: {enrollment.Status}, " +
                    $"Final Grade: {enrollment.FinalGrade}");
            }
        }

        public static void UpdateEnrollment(ApplicationDbContext context, int studentId, int courseId, decimal newProgress, decimal? finalGrade)
        {
            var enrollment = context.Enrollments
                    .FirstOrDefault(e => e.StudentId == studentId &&
                             e.CourseId == courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100.");
                return;
            }

            if (newProgress < 100 && finalGrade != null)
            {
                Console.WriteLine(
                    "Final Grade is only allowed when the course is completed.");
                return;
            }

            enrollment.Progress = newProgress;

            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
                enrollment.FinalGrade = finalGrade;
            }

            context.SaveChanges();

            Console.WriteLine("Enrollment updated successfully.");
        }

        public static void DeleteEnrollment(ApplicationDbContext context, int studentId, int courseId)
        {
            var enrollment = context.Enrollments
                .FirstOrDefault(e => e.StudentId == studentId &&
                                     e.CourseId == courseId);

            if (enrollment != null)
            {
                context.Enrollments.Remove(enrollment);
                context.SaveChanges();

                Console.WriteLine("Enrollment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Enrollment not found.");
            }
        }

        public static void DeleteDroppedEnrollments(ApplicationDbContext context)
        {
            int affectedRows = context.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Dropped)
                .ExecuteDelete();

            Console.WriteLine($"Deleted enrollments: {affectedRows}");
        }
    }
}
