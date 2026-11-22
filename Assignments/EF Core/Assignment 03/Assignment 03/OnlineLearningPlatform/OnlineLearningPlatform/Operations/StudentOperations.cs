using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLearningPlatform.Operations
{
    public class StudentOperations
    {
        public static void AddStudent(ApplicationDbContext context)
        {
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Ahmed Samir",
                    Email = "ahmed.samir@example.com",
                    DateOfBirth = new DateTime(2002, 5, 10)
                },

                new Student
                {
                    FullName = "Mariam Ali",
                    Email = "mariam.ali@example.com",
                    DateOfBirth = new DateTime(2003, 8, 15)
                },

                new Student
                {
                    FullName = "Omar Hassan",
                    Email = "omar.hassan@example.com",
                    DateOfBirth = new DateTime(2001, 3, 20)
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            foreach(var student in students)
            {
                Console.WriteLine($"Student added: {student.FullName}, ID: {student.Id}");
            }
        }

        public static void GetAllStudents(ApplicationDbContext context)
        {
            var students = context.Students.ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FullName}, Email: {student.Email}");
            }
        }

        public static void UpdateStudent(ApplicationDbContext context, int studentId, string newName)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == studentId);

            if(student != null)
            {
                student.FullName = newName;
                context.SaveChanges();
            }
        }

        public static void DeleteStudent(ApplicationDbContext context, int studentId)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == studentId);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();

                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
