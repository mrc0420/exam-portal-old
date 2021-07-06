using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPortal18UI.ViewModel
{
    public class QuestionViewModel
    {
        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Answer { get; set; }

        public string QuestionId { get; set; }

        public int CourseId { get; set; }
    }
}
