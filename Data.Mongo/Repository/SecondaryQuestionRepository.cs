using Data.Mongo.Mdo;
using Data.Mongo.Repository;
using Data.Mongo.Repository.Helper;
using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using Domain.Question.Abstract.Repository.Document;
using Infrastructure.Common.Factory.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mongo
{
    public class SecondaryQuestionRepository : ISecondaryQuestionRepository
    {

        private readonly IFactoryProvider _factoryProvider;

        public SecondaryQuestionRepository(IFactoryProvider factoryProvider)
        {

            _factoryProvider = factoryProvider;
        }

       

        public IEnumerable<IQuestionFromSecondaryStorage> GetQuestions(int courseId)
        {
            var database = MongoConnection.Connection();
            var collections = database.GetCollection<QuestionsMdo>("Questions");
            var filter = Builders<QuestionsMdo>.Filter.Eq("CourseId", courseId);
            var questions = collections.Find(filter).ToList();
            return questions.ToDomain(_factoryProvider);
        }

        public void InsertQuestions(IEnumerable<IQuestionFromPrimaryStorage> questions)
        {
            var database = MongoConnection.Connection();
           database.DropCollection("Questions");
            var collection = database.GetCollection<QuestionsMdo>("Questions");
            var QuestionMdo = questions.ToDocumentMdo();
            collection.InsertManyAsync(QuestionMdo);
            //foreach (var question in QuestionMdo)
            //{
            //    collection.InsertOneAsync(question);
            //}

        }
    }
}
