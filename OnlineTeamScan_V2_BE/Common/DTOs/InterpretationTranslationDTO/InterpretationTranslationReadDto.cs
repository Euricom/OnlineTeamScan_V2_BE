using Common.DTOs.InterpretationDTO;
using Common.DTOs.LanguageDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.InterpretationTranslationDTO
{
    public class InterpretationTranslationReadDto
    {
        public string Text { get; set; }

        public LanguageReadDto Language { get; set; }
        public InterpretationReadDto Interpretation { get; set; }
    }
}
