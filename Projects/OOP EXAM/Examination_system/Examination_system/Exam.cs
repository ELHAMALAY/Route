using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_system
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int TimeInMinutes { get; set; }
        public int NumberOfQuestions => Questions.Count;
        public List<Question> Questions { get; protected set; }
        public Subject? Subject { get; set; }

        protected Exam(int timeInMinutes)
        {
            TimeInMinutes = timeInMinutes;
            Questions = new List<Question>();
        }

        protected abstract bool IsQuestionTypeAllowed(Question q);

        public void AddQuestion(Question q)
        {
            if (!IsQuestionTypeAllowed(q))
                throw new InvalidOperationException(
                    $"{q.GetType().Name} is not allowed in a {GetType().Name}.");
            Questions.Add(q);
        }

        public abstract void ShowExam();
        public virtual object Clone()
        {
            var clonedQuestions = Questions.Select(q => (Question)q.Clone()).ToList();
            var clone = CloneCore();
            clone.Questions = clonedQuestions;
            return clone;
        }

        protected abstract Exam CloneCore();

        public int CompareTo(Exam? other)
        {
            if (other is null) return 1;
            return TimeInMinutes.CompareTo(other.TimeInMinutes);
        }

        public override string ToString()
        {
            return $"{GetType().Name} | Subject: {Subject?.SubjectName} | " +
                   $"{TimeInMinutes} min | {NumberOfQuestions} question(s)";
        }
    }
}
