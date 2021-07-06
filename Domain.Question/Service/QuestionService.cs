using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using Domain.Question.Abstract.Repository.Document;
using Domain.Question.Abstract.Repository.Entity;
using Domain.Question.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Question.Service
{
    public class QuestionService : IQuestionService
    {
        ISecondaryQuestionRepository _SecondaryQuestionRepository;
        IPrimaryQuestionRepository _primaryQuestionRepository;

        public QuestionService(ISecondaryQuestionRepository SecondaryQuestionRepository, IPrimaryQuestionRepository primaryQuestionRepository)
        {

            _SecondaryQuestionRepository = SecondaryQuestionRepository;
            _primaryQuestionRepository = primaryQuestionRepository;

        }

        public void AddQuestion(IQuestionFromPrimaryStorage questionToPrimary)
        {
            _primaryQuestionRepository.AddQuestion(questionToPrimary);
        }

        public void DeleteQuestion(string questionId)
        {
            _primaryQuestionRepository.DeleteQuestion(questionId);
        }

        public void InsertQuestionToSecondary()
        {
            IEnumerable<IQuestionFromPrimaryStorage> questions = _primaryQuestionRepository.QuestionsRead();
            _SecondaryQuestionRepository.InsertQuestions(questions);

        }

        public IEnumerable<IQuestionFromSecondaryStorage> ReadQuestions(int courseId)
        {
            return _SecondaryQuestionRepository.GetQuestions(courseId);
        }
    }
}
