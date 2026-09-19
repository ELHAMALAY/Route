using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Examination_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Examination System =====\n");

            int subjectId = ReadInt("Subject Id: ");
            string subjectName = ReadNonEmpty("Subject Name: ");
            var subject = new Subject(subjectId, subjectName);

            ExamType examType = ReadExamType();
            int timeInMinutes = ReadInt("Exam duration (minutes): ");
            var exam = subject.CreateExam(examType, timeInMinutes);

            int numberOfQuestions = ReadInt("Number of questions: ");

            for (int i = 1; i <= numberOfQuestions; i++)
            {
                Console.WriteLine($"\n-- Question {i} --");
                string body = ReadNonEmpty("Question text: ");
                int mark = ReadInt("Mark: ");

                Question question;

                if (examType == ExamType.Practical)
                {
                    question = BuildMCQ($"Q{i}", body, mark);
                }
                else
                {
                    Console.WriteLine("Question type: 1) True/False   2) MCQ");
                    int typeChoice = ReadIntInRange("Choice: ", 1, 2);
                    question = typeChoice == 1
                        ? BuildTrueFalse($"Q{i}", body, mark)
                        : BuildMCQ($"Q{i}", body, mark);
                }

                exam.AddQuestion(question);
            }

            Console.WriteLine();
            var stopwatch = Stopwatch.StartNew();
            exam.ShowExam();
            stopwatch.Stop();

            Console.WriteLine($"Time = {stopwatch.Elapsed}");
            Console.WriteLine("Thank you");
        }

        static TrueFalseQuestion BuildTrueFalse(string header, string body, int mark)
        {
            Console.Write("Correct answer (True/False): ");
            bool correctIsTrue;
            while (!bool.TryParse(Console.ReadLine(), out correctIsTrue))
                Console.Write("Please type True or False: ");

            return new TrueFalseQuestion(header, body, mark, correctIsTrue);
        }

        static MCQQuestion BuildMCQ(string header, string body, int mark)
        {
            int choiceCount = ReadIntInRange("Number of choices: ", 2, 10);
            var choices = new List<Answer>();

            for (int c = 1; c <= choiceCount; c++)
            {
                string text = ReadNonEmpty($"  Choice {c} text: ");
                choices.Add(new Answer(c, text, false));
            }

            int correctIndex = ReadIntInRange("Correct choice number: ", 1, choiceCount);
            return new MCQQuestion(header, body, mark, choices, correctIndex);
        }

        static ExamType ReadExamType()
        {
            Console.WriteLine("Exam type: 1) Final   2) Practical");
            int choice = ReadIntInRange("Choice: ", 1, 2);
            return choice == 1 ? ExamType.Final : ExamType.Practical;
        }

        static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Please enter a valid number: ");
            return value;
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            int value = ReadInt(prompt);
            while (value < min || value > max)
                value = ReadInt($"Please enter a number between {min} and {max}: ");
            return value;
        }

        static string ReadNonEmpty(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine() ?? "";
            while (string.IsNullOrWhiteSpace(value))
            {
                Console.Write("This can't be empty, try again: ");
                value = Console.ReadLine() ?? "";
            }
            return value;
        }
    }
}