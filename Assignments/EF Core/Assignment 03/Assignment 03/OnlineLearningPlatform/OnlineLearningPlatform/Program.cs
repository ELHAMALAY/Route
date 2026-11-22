
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using OnlineLearningPlatform.Operations;

namespace OnlineLearningPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDbContext();

            // Seed Data
            DataSeeder.Seed(context);

            // =========================
            // Create Operations
            // =========================

            InstructorOperations.AddInstructor(context);
            StudentOperations.AddStudent(context);

            CourseOperations.AddCourse(context);

            EnrollmentOperations.AddEnrollment(context, 1, 1);

            // =========================
            // Read Operations
            // =========================

            StudentOperations.GetAllStudents(context);
            InstructorOperations.GetAllInstructors(context);
            CategoryOperations.GetAllCategories(context);
            CourseOperations.GetAllCourses(context);
            EnrollmentOperations.GetAllEnrollments(context);

            CourseOperations.FindCourseById(context, 1);
            CourseOperations.FindCourseByTitle(context, "C# Fundamentals");

            CourseOperations.FilterCourses(context, 100, 1000);

            CategoryOperations.GetSubCategories(context, 1);
            CategoryOperations.GetTopLevelCategories(context);

            CourseOperations.GetCourseRoster(context, 1);

            // =========================
            // Update Operations
            // =========================

            StudentOperations.UpdateStudent(context, 6, "Ahmed Updated");

            InstructorOperations.UpdateInstructor(context, 1, "Ahmed Updated", "ahmed.updated@example.com");

            CourseOperations.ChangeCoursePrice(context, 1, 750);

            EnrollmentOperations.UpdateEnrollment(context, 1, 1, 50, null);

            CourseOperations.PublishCourse(context, 7);

            // =========================
            // Delete Operations
            // =========================

            EnrollmentOperations.DeleteEnrollment(context, 1, 1);

            CategoryOperations.TryDeleteCategory(context, 1);
            CategoryOperations.SafeDeleteCategory(context, 1);

            StudentOperations.DeleteStudent(context, 7);

            CourseOperations.DeleteCourse(context, 7);

            // =========================
            // Bulk Operations
            // =========================

            CourseOperations.IncreasePublishedCoursesPrices(
                context,
                CourseLevel.Beginner);

            EnrollmentOperations.DeleteDroppedEnrollments(context);
        }
    }
}
