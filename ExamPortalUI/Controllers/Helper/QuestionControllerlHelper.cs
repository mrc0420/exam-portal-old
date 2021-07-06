using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using ExamPortal18UI.ViewModel;
using Infrastructure.Common.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPortal18UI.Controllers.Helper
{
    public static class QuestionControllerlHelper
    {
        public static IEnumerable<QuestionViewModel> ToViewModel(this IEnumerable<IQuestionFromSecondaryStorage> questions)
        {
            return questions.Select(x => new QuestionViewModel
            {
                Answer = x.Answer,
                Option1 = x.Option1,
                Option2 = x.Option2,
                Question = x.Question,
                QuestionId = x.QuestionId,
                CourseId = x.CourseId,

            }).ToList();
        }

        //public static IEnumerable<IQuestionFromPrimaryStorage> ToDomain(this QuestionViewModel questions, IFactoryProvider factoryProvider)
        //{
        //    return questions.Select(x => x.ToDomain(factoryProvider)).ToList();
        //}


        public static IQuestionFromPrimaryStorage ToDomain( this QuestionViewModel questionViewModel, IFactoryProvider factoryProvider)
        {
            var questionModel = factoryProvider.Create<IQuestionFromPrimaryStorage>();
            questionModel.CourseId = questionViewModel.CourseId;
            questionModel.QuestionId = questionViewModel.QuestionId;
            questionModel.Question = questionViewModel.Question;
            questionModel.Option1 = questionViewModel.Option1;
            questionModel.Option2 = questionViewModel.Option2;
            questionModel.Answer = questionViewModel.Answer;

            return questionModel;

        }
    }
}
