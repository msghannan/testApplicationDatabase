using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoNum { get; set; }
        public char title { get; set; }
        public string Grade { get; set; }
    }
}
