using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Question.Abstract.Repository.Document
{
  public interface ISecondaryQuestionRepository
    {

        IEnumerable<IQuestionFromSecondaryStorage> GetQuestions(int courseId);
        void InsertQuestions(IEnumerable<IQuestionFromPrimaryStorage> questions);

    }
}
