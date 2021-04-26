using Common.DTOs.DysfunctionDTO;
using Common.DTOs.LanguageDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.DysfunctionTranslationDTO
{
    public class DysfunctionTranslationReadDto
    {
        public string Name { get; set; }

        public LanguageReadDto Language { get; set; }
        public DysfunctionReadDto Dysfunction { get; set; }
    }
}
