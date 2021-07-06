using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mongo.Mdo
{
 public   class QuestionsMdo
    {
        public ObjectId _id { get; set; }
        public int CourseId { get; set; }

        public string QuestionId { get; set; }

        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Answer { get; set; }
    }
}
