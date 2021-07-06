using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Question.Abstract.Document
{
    public interface IQuestionFromSecondaryStorage
    {
        int CourseId { get; set; }
        string QuestionId { get; set; }

        string Question { get; set; }

        string Option1 { get; set; }

        string Option2 { get; set; }

        string Answer { get; set; }


    }
}
