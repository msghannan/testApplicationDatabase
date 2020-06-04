using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplicationDatabase.Models;

namespace TestApplicationDatabase.ViewModels
{
    public class ExamHistoryViewModel
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public Person Person { get; set; }
        public Test Test { get; set; }
    }
}
