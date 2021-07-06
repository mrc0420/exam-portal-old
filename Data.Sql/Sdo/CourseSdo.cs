using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Sql.Sdo
{
  public  class CourseSdo
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int PassPercentage { get; set; }
    }
}
