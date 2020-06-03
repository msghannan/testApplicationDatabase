using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Test
    {
        public int ID { get; set; }
        public string TestName { get; set; }
        public double MaxPoints { get; set; }
        public DateTime Date { get; set; }
        public List<Question> Questions { get; set; }
        public Test()
        {
            Questions = new List<Question>();
        }
    }
}