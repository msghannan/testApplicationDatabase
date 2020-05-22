using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Role
    {
        public int Id { get; set; }
        public bool Teacher { get; set; }
        public bool Student { get; set; }
        public int PersonId { get; set; }
    }
}
