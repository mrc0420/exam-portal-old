using Data.Mongo.Mdo;
using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using Infrastructure.Common.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Mongo.Repository.Helper
{
    public static class QuestionMapper
    {

        public static IEnumerable<IQuestionFromSecondaryStorage> ToDomain(
           this IEnumerable<QuestionsMdo> questions,
           IFactoryProvider factoryProvider)
        {
            IEnumerable<IQuestionFromSecondaryStorage> z = questions.Select(x => x.ToDomain(factoryProvider)).ToList();
            return z;



        }

        public static IQuestionFromSecondaryStorage ToDomain(this QuestionsMdo questionMdo, IFactoryProvider factoryProvider)
        {
            var question = factoryProvider.Create<IQuestionFromSecondaryStorage>();


            question.Answer = questionMdo.Answer;
            question.Option1 = questionMdo.Option1;
            question.Option2 = questionMdo.Option2;
            question.Question = questionMdo.Question;
            question.QuestionId = questionMdo.QuestionId;
            question.CourseId = questionMdo.CourseId;


            return question;
        }

        public static IEnumerable<QuestionsMdo> ToDocumentMdo(this IEnumerable<IQuestionFromPrimaryStorage> question)
        {
            return question.Select(x => new QuestionsMdo
            {
                Answer = x.Answer,
                CourseId = x.CourseId,
                Option1 = x.Option1,
                Option2 = x.Option2,
                Question = x.Question,
                QuestionId = x.QuestionId

            }).ToList();
        }

        //public static QuestionsMdo ToDocumentMdo(this IQuestionFromPrimaryStorage question)
        //{
        //    if (question == null)
        //    {
        //        throw new ArgumentNullException(nameof(question));
        //    }

        //    return new QuestionsMdo
        //    {
        //        Answer = question.Answer,
        //        CourseId = question.CourseId,
        //        Option1 = question.Option1,
        //        Option2 = question.Option2,
        //        Question = question.Question,
        //        QuestionId = question.QuestionId

        //    };
        //}

    }
}
