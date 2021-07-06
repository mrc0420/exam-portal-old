using Domain.Course.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Course.Entity
{
    public class Course : ICourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int PassPercentage { get; set; }
    }
}
