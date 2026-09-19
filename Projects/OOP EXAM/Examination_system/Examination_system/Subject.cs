using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_system
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public Exam CreateExam(ExamType type, int timeInMinutes)
        {
            Exam exam = type switch
            {
                ExamType.Final => new FinalExam(timeInMinutes),
                ExamType.Practical => new PracticalExam(timeInMinutes),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };

            exam.Subject = this;
            Exam = exam;
            return exam;
        }

        public override string ToString() => $"[{SubjectId}] {SubjectName}";
    }
}
