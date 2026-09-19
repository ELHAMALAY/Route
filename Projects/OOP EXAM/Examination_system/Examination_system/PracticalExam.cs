using System;

namespace Examination_system
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeInMinutes) : base(timeInMinutes) { }

        protected override bool IsQuestionTypeAllowed(Question q) => q is MCQQuestion;

        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam Results:");
            int index = 1;

            foreach (var q in Questions)
            {
                Console.WriteLine($"Question {index}: {q.Body}");
                q.AskUser();   // بس بياخد الإجابة، من غير ما يقول صح/غلط دلوقتي
                Console.WriteLine();
                index++;
            }

            Console.WriteLine("-- Exam finished. Correct answers: --");
            index = 1;
            foreach (var q in Questions)
            {
                Console.WriteLine($"Question {index}: {q.CorrectAnswerId.AnswerText}");
                index++;
            }
        }

        protected override Exam CloneCore() => new PracticalExam(TimeInMinutes) { Subject = Subject };
    }
}