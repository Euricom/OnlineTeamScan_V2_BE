using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.RecommendationTranslationRepositories
{
    public class RecommendationTranslationRepository : GenericRepository<RecommendationTranslation>, IRecommendationTranslationRepository
    {
        public RecommendationTranslationRepository(OnlineTeamScanContext context) : base(context)
        { }

        public IEnumerable<RecommendationTranslation> GetAllRecommendationTranslationByLanguageId(int languageId)
        {
            return GetAll(filter: recommendation => recommendation.LanguageId == languageId, orderBy: recommendation => recommendation.OrderBy(prop => prop.RecommendationId), includeProperties: recommendation => recommendation.Recommendation);
        }
    }
}
