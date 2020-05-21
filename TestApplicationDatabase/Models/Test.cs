using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Test
    {
        public int ID { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public double MaxPoints { get; set; }
        public DateTime Date { get; set; }

    }
}


/*
 * 1, Antagningstest, 50, 2020-05-05 
 * 2, Matte, 30, 2030-02-02
*/
