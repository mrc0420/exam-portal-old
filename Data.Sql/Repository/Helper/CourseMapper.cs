using Data.Sql.Sdo;
using Domain.Course.Abstract.Entity;
using Infrastructure.Common.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Sql.Repository.Helper
{
    public static class CourseMapper
    {
        public static IEnumerable<ICourse> ToDomain(this IEnumerable<CourseSdo> Courses, IFactoryProvider factoryProvider)
        {
            IEnumerable<ICourse> courses = Courses.Select(x => x.ToDomain(factoryProvider));
            
            return courses;

        }

        public static ICourse ToDomain(this CourseSdo courseSdo, IFactoryProvider factoryProvider)
        {
            var course = factoryProvider.Create<ICourse>();


            course.CourseId = courseSdo.CourseId;
            course.CourseName = courseSdo.CourseName;
            course.PassPercentage = courseSdo.PassPercentage;

            return course;
        }
    }
}
