using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_system
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer CorrectAnswerId { get; set; }

        protected Question(string header, string body, int mark, List<Answer> answerList, Answer correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswerId = correctAnswerId;
        }

        public virtual Answer AskUser()
        {
            foreach (var a in AnswerList)
                Console.WriteLine($"   - {a.AnswerText}");

            Console.Write("Your answer: ");
            string input = (Console.ReadLine() ?? "").Trim();

            return AnswerList.FirstOrDefault(a =>
                       string.Equals(a.AnswerText, input, StringComparison.OrdinalIgnoreCase))
                   ?? new Answer(-1, input, false);
        }

        public virtual object Clone()
        {
            var clonedAnswers = AnswerList.Select(a => (Answer)a.Clone()).ToList();
            var clonedCorrect = (Answer)CorrectAnswerId.Clone();
            return CloneCore(clonedAnswers, clonedCorrect);
        }

        protected abstract Question CloneCore(List<Answer> clonedAnswers, Answer clonedCorrect);

        public int CompareTo(Question? other)
        {
            if (other is null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"{GetType().Name} | {Header} ({Mark} pts)\n  {Body}\n  " +
                   $"Answers: {string.Join(", ", AnswerList)}";
        }
    }
}