﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QuestionTranslation
    {
        public int LanguageId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public Language Language { get; set; }
        public Question Question { get; set; }
    }
}
