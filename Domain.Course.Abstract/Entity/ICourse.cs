using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Course.Abstract.Entity
{
 public   interface ICourse
    {
        int CourseId { get; set; }
        string CourseName { get; set; }
        int PassPercentage { get; set; }
    }
}
