using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace Assignment_03
{
    internal class Exercise1 : IExercise
    {
        public void Run()
        {
            //1.
            List<int> studentGrade = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };
            
            //2.
            Console.Write("Grades: ");
            Console.WriteLine(string.Join(", ",studentGrade));

            Console.WriteLine($"Count: {studentGrade.Count}");
            Console.WriteLine($"First grade: {studentGrade.First()}");
            Console.WriteLine($"Last grade: {studentGrade.Last()}");

            //3.
            studentGrade.Sort();

            Console.Write("\nSorted Grades: ");
            Console.WriteLine(string.Join(", ", studentGrade));

            //4.
            int firstAbove90 = studentGrade.First(g => g > 90);
            Console.WriteLine($"\nFirst grade above 90: {firstAbove90}");

            //5.
            List<int> failingGrades = studentGrade.Where(g => g < 75).ToList();
            Console.Write("\nFailing Grades: ");
            Console.WriteLine(string.Join(", ", failingGrades));

            //6.
            studentGrade.RemoveAll(g => g < 75);
            Console.Write("\nGrades after removing failing grades: ");
            Console.WriteLine(string.Join(", ", studentGrade));

            //7.
            bool has100 = studentGrade.Any(g => g == 100);
            Console.WriteLine($"\nContains grade 100: {has100}");

            //8.
            List<string> gradeStrings = studentGrade.Select(g => $"Grade = {g}").ToList();
            Console.Write("\nGrade Strings: ");
            Console.WriteLine(string.Join(", ", gradeStrings));
        }
    }
}
