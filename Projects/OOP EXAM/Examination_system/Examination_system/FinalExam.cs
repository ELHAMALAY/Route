using System;
using System.Collections.Generic;

namespace Examination_system
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeInMinutes) : base(timeInMinutes) { }

        protected override bool IsQuestionTypeAllowed(Question q)
            => q is TrueFalseQuestion || q is MCQQuestion;

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam Results:");
            int totalMarks = 0, scored = 0;
            int index = 1;

            foreach (var q in Questions)
            {
                totalMarks += q.Mark;
                Console.WriteLine($"Question {index}: {q.Body}");

                var userAnswer = q.AskUser();
                Console.WriteLine($"Your Answer => {userAnswer.AnswerText}");
                Console.WriteLine($"Correct Answer => {q.CorrectAnswerId.AnswerText}");
                Console.WriteLine();

                if (userAnswer.AnswerId == q.CorrectAnswerId.AnswerId)
                    scored += q.Mark;

                index++;
            }

            Console.WriteLine($"Your Grade is {scored} from {totalMarks}");
        }

        protected override Exam CloneCore() => new FinalExam(TimeInMinutes) { Subject = Subject };
    }
}