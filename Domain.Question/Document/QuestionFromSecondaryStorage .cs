using Domain.Question.Abstract.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Question.Document
{
    public class QuestionFromSecondaryStorage : IQuestionFromSecondaryStorage
    {
        public int CourseId { get; set; }

        public string QuestionId { get; set; }

        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Answer { get; set; }
    }
}
