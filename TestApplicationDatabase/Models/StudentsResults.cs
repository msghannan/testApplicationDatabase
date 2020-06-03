using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class StudentsResults
    {
        public int Id { get; set; }
        public Person Student { get; set; }

        public Test Exam { get; set; }
        public string Grade { get; set; }
    }
}
