using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Course.Abstract.Service;
using ExamPortal18UI.Controllers.Helper;
using ExamPortal18UI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortal18UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: api/Course
        [HttpGet]
        public IEnumerable<CourseViewModel> Get()
        {
         var  courses = _courseService.ReadCourses();

            return courses.ToViewModel();

        }

        // GET: api/Course/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Course
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
