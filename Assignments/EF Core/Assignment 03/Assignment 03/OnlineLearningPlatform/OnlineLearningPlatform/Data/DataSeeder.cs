using System;
using System.Collections.Generic;
using System.Text;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using System.Linq;

namespace OnlineLearningPlatform.Data
{
    public class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            SeedStudents(context);
            SeedEnrollments(context);
        }

        private static void SeedStudents(ApplicationDbContext context)
        {
            if(!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        FullName = "Ali Mohamed",
                        Email = "ali@example.com",
                        DateOfBirth = new DateTime(2002, 5, 10)
                    },
                    new Student
                    {
                        FullName = "Omar Ahmed",
                        Email = "omar@example.com",
                        DateOfBirth = new DateTime(2001, 8, 15)
                    },
                    new Student
                    {
                        FullName = "Sara Mahmoud",
                        Email = "sara.student@example.com",
                        DateOfBirth = new DateTime(2003, 2, 20)
                    },
                    new Student
                    {
                        FullName = "Mona Hassan",
                        Email = "mona@example.com",
                        DateOfBirth = new DateTime(2002, 11, 5)
                    },
                    new Student
                    {
                        FullName = "Khaled Ali",
                        Email = "khaled@example.com",
                        DateOfBirth = new DateTime(2000, 7, 25)
                    }
                };

                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }


        private static void SeedEnrollments(ApplicationDbContext context)
        {
            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 1, 10),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 95
                    },

                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2026, 1, 15),
                        Progress = 40,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },
                    new Enrollment

                    {
                        StudentId = 2,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 1, 20),
                        Progress = 60,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },

                    new Enrollment

                    {
                        StudentId = 2,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2026, 1, 25),
                        Progress = 30,
                        Status = EnrollmentStatus.Dropped,
                        FinalGrade = null
                    },

                    new Enrollment
                    {
                        StudentId = 3,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 2, 1),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 88
                    },

                    new Enrollment
                    {
                        StudentId = 3,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2026, 2, 5),
                        Progress = 70,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },

                    new Enrollment
                    {
                        StudentId = 4,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 2, 10),
                        Progress = 50,
                        Status = EnrollmentStatus.Active,
                        FinalGrade = null
                    },

                    new Enrollment
                    {
                        StudentId = 5,
                        CourseId = 2,
                        EnrollmentDate = new DateTime(2026, 2, 15),
                        Progress = 100,
                        Status = EnrollmentStatus.Completed,
                        FinalGrade = 92
                    }
                };

                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}
