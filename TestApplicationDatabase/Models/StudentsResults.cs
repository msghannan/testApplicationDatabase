using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class StudentsResults
    {
        public int Id { get; set; }
        public string Grade { get; set; } 
        public int PersonId { get; set; } 
        public int TestId { get; set; } 
    }
}
