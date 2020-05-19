using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class QuestionTest
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
