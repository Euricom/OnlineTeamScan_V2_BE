using Common.DTOs.LanguageDTO;
using Common.DTOs.QuestionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.QuestionTranslationDTO
{
    public class QuestionTranslationReadDto
    {
        public string Text { get; set; }

        public LanguageReadDto Language { get; set; }
        public QuestionReadDto Question { get; set; }
    }
}
