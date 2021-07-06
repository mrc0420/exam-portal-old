using Data.Sql.Sdo;
using Domain.Question.Abstract.Entity;
using Infrastructure.Common.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Sql.Repository.Helper
{
 public static  class QuestionMapper
    {

        public static IEnumerable<IQuestionFromPrimaryStorage> ToDomainQuestions(this IEnumerable<QuestionsSdo> questionsSdos, IFactoryProvider factoryProvider)
        {
            var questions = questionsSdos.Select(x => x.ToDomain(factoryProvider)).ToList();
            return questions;

        }

        public static IQuestionFromPrimaryStorage ToDomain(this QuestionsSdo questionsSdo, IFactoryProvider factoryProvider)
        {
            var question = factoryProvider.Create<IQuestionFromPrimaryStorage>();


            question.CourseId = questionsSdo.CourseId;
            question.QuestionId = questionsSdo.QuestionId;
            question.Question = questionsSdo.Question;
            question.Option1 = questionsSdo.Option1;
            question.Option2 = questionsSdo.Option2;
            question.Answer = questionsSdo.Answer;



            return question;
        }

        public static QuestionsSdo ToSdo( this IQuestionFromPrimaryStorage questionToPrimary)
        {

            QuestionsSdo questionsSdo = new QuestionsSdo();
            questionsSdo.CourseId = questionToPrimary.CourseId;
            questionsSdo.QuestionId = questionToPrimary.QuestionId;
            questionsSdo.Question = questionToPrimary.Question;
            questionsSdo.Option1 = questionToPrimary.Option1;
            questionsSdo.Option2 = questionToPrimary.Option2;
            questionsSdo.Answer = questionToPrimary.Answer;

            return questionsSdo;
        }



    }
}
