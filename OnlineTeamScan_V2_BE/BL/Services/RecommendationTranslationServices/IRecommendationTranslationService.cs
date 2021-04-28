using Common.DTOs.RecommendationTranslationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.RecommendationTranslationServices
{
    public interface IRecommendationTranslationService
    {
        public IEnumerable<RecommendationTranslationReadDto> GetAllRecommendationTranslationByLanguageId(int languageId);
    }
}
