using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_system
{
    public class Answer : ICloneable
    {
        private int v1;
        private string v2;

        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public Answer(int answerId, string answerText, bool isCorrectAnswer)
        {
            AnswerId = answerId;
            AnswerText = answerText;
            IsCorrectAnswer = isCorrectAnswer;
        }

    

        public override string ToString()
        {
            return $"[{AnswerId}] {AnswerText}";
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText, IsCorrectAnswer);
        }
    }
}
