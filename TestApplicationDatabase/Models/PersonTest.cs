using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class PersonTest
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
