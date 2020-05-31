﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplicationDatabase.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool CorrectAnswer { get; set; }
        public int QuestionId { get; set; }
        
    }
}
