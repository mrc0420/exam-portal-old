using Domain.Question.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Question.Abstract.Repository.Entity
{
  public  interface IPrimaryQuestionRepository
    {
        IEnumerable<IQuestionFromPrimaryStorage> QuestionsRead();
        void DeleteQuestion(string questionId);
        void AddQuestion(IQuestionFromPrimaryStorage primaryQuestion);

    }
}
