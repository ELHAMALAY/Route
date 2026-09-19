using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_system
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, bool correctIsTrue)
           : base(header, body, mark, BuildAnswers(correctIsTrue), null!)
        {
            CorrectAnswerId = AnswerList.First(a => a.IsCorrectAnswer);
        }

        private static List<Answer> BuildAnswers(bool correctIsTrue)
        {
            return new List<Answer>
            {
                new Answer(1, "True", correctIsTrue),
                new Answer(2, "False", !correctIsTrue)
            };
        }

        protected override Question CloneCore(List<Answer> clonedAnswers, Answer clonedCorrect)
        {
            bool correctIsTrue = clonedCorrect.AnswerText == "True";
            return new TrueFalseQuestion(Header, Body, Mark, correctIsTrue)
            {
                AnswerList = clonedAnswers,
                CorrectAnswerId = clonedCorrect
            };
        }
    }
}