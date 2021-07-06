using Domain.Course.Abstract.Entity;
using ExamPortal18UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPortal18UI.Controllers.Helper
{
    public static class CourseControllerHelper
    {
        public static IEnumerable<CourseViewModel> ToViewModel(this IEnumerable<ICourse> course)
        {
            return course.Select(x => new CourseViewModel
            {

                PassPercentage = x.PassPercentage,
                CourseName = x.CourseName,
                CourseId = x.CourseId,

            }).ToList();

        }
    }
}
