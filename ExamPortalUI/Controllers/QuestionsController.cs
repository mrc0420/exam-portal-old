using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Question.Abstract.Repository.Document;
using Domain.Question.Abstract.Service;
using ExamPortal18UI.Controllers.Helper;
using ExamPortal18UI.ViewModel;
using Hangfire;
using Infrastructure.Common.Factory.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortal18UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService _questionService;
        IBackgroundJobClient _backgroundJobs;
        IFactoryProvider _factoryProvider;

        public QuestionsController(IQuestionService questionService, IBackgroundJobClient backgroundJobs, IFactoryProvider factoryProvider)
        {
            _questionService = questionService;
            _backgroundJobs = backgroundJobs;
            _factoryProvider = factoryProvider;
        }

        // GET: api/Questions
        [HttpGet]
        public IList<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Questions/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<QuestionViewModel> Get(int id)
        {
            _backgroundJobs.Enqueue(() => _questionService.InsertQuestionToSecondary());
            var questions = _questionService.ReadQuestions(id);

            return questions.ToViewModel();
        }

        // POST: api/Questions
        [HttpPost]
        [Route("AddQuestion")]
        public void Post(QuestionViewModel questionViewModel)

        {
            var question = questionViewModel.ToDomain(_factoryProvider);
            _questionService.AddQuestion(question);
            

        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public string Delete(string id)
        {
            _questionService.DeleteQuestion(id);

            var message = "Record deleted";
            return message;
        }
}
}
