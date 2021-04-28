using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.RecommendationTranslationRepositories
{
    public interface IRecommendationTranslationRepository : IGenericRepository<RecommendationTranslation>
    {
        public IEnumerable<RecommendationTranslation> GetAllRecommendationTranslationByLanguageId(int languageId);
    }
}
