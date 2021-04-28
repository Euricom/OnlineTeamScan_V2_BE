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

        public InterpretationTranslation GetInterpretationTranslationByLanguage(int id, int languageId)
        {
            return GetAll(filter: interpretationTranslation => interpretationTranslation.InterpretationId == id && interpretationTranslation.LanguageId == languageId,
                includeProperties: interpretationTranslation => interpretationTranslation.Interpretation).FirstOrDefault();
        }
    }
}
