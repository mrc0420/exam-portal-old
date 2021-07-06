using Domain.Course.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Course.Abstract.Service
{
   public interface ICourseService
    {
        IEnumerable<ICourse> ReadCourses();
    }
}
