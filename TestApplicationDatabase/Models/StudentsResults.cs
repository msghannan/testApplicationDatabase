using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class StudentsResults
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string Grade { get; set; }
    }
}
