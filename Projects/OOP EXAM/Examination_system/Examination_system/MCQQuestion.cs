using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_system
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark,
                            List<Answer> choices, int correctAnswer)
            : base(header, body, mark, choices,
                   choices.First(a => a.AnswerId == correctAnswer))
        {
            foreach (var a in AnswerList) a.IsCorrectAnswer = a.AnswerId == correctAnswer;
        }


        protected override Question CloneCore(List<Answer> clonedAnswers, Answer clonedCorrect)
        {
            return new MCQQuestion(Header, Body, Mark, clonedAnswers, clonedCorrect.AnswerId);
        }
    }
}
