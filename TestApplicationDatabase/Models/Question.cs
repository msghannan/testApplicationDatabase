using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }

        public List<Answer> Answers { get; set; }

        public int TestID { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }

    }
}

