using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Sql.Sdo
{
   public class QuestionsSdo
    {

        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Answer { get; set; }

        public string QuestionId { get; set; }

        public int CourseId { get; set; }
    }
}
