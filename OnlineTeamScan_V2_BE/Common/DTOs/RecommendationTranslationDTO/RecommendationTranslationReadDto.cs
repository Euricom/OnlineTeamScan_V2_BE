using Common.DTOs.LanguageDTO;
using Common.DTOs.RecommendationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.RecommendationTranslationDTO
{
    public class RecommendationTranslationReadDto
    {      
        public string Title { get; set; }
        public string Text { get; set; }
        public LanguageReadDto Language { get; set; }
        public RecommendationReadDto Recommendation { get; set; }
    }
}
