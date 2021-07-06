using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Question.Abstract.Service
{
  public  interface IQuestionService
    {
        IEnumerable<IQuestionFromSecondaryStorage> ReadQuestions(int courseId);
        void InsertQuestionToSecondary();
        void DeleteQuestion(string questionId);
        void AddQuestion(IQuestionFromPrimaryStorage questionToPrimary);
    }
}
