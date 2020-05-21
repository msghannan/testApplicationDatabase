using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class PersonTest
    {
        [Key]
        public int ID { get; set; }
        public int PersonId { get; set; }
        public int TestId { get; set; }
        public double Score { get; set; }
    }
}


/*
 
 *, 3, 2, 25.5 

 */
