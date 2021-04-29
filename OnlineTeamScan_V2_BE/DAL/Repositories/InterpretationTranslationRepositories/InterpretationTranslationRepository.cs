using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories.InterpretationTranslationRepositories
{
    public class InterpretationTranslationRepository : GenericRepository<InterpretationTranslation>, IInterpretationTranslationRepository
    {
        public InterpretationTranslationRepository(OnlineTeamScanContext context) : base(context)
        { }

        public InterpretationTranslation GetTranslatedInterpretationTranslationByLevelAndDysfunction(int levelId, int dysfunctionId, int languageId)
        {
            return _dbSet.Include(interpretationTranslation => interpretationTranslation.Interpretation)
                .Where(interpretationTranslation => interpretationTranslation.LanguageId == languageId 
                 && interpretationTranslation.Interpretation.LevelId == levelId 
                 && interpretationTranslation.Interpretation.DysfunctionId == dysfunctionId)
                .FirstOrDefault();
        }
    }
}
