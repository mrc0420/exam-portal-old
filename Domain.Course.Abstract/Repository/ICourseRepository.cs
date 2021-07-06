using Domain.Course.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Course.Abstract.Repository
{
  public  interface ICourseRepository
    {
        IEnumerable<ICourse> ReadCourseList();
    }
}
