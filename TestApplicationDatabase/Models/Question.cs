using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }

        public List<string> ChoiseList = new List<string>() ;
        public List<string> QuestionsList = new List<string>();

    }
}

