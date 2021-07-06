using Domain.Course.Abstract.Entity;
using Domain.Course.Abstract.Repository;
using Domain.Course.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Course.Service
{
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
            
        public IEnumerable<ICourse> ReadCourses()
        {
            return _courseRepository.ReadCourseList();
        }
    }
}
