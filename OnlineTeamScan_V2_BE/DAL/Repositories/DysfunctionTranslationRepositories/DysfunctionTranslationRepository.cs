using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.DysfunctionTranslationRepositories
{
    public class DysfunctionTranslationRepository : GenericRepository<DysfunctionTranslation>, IDysfunctionTranslationRepository
    {
        public DysfunctionTranslationRepository(OnlineTeamScanContext context) : base(context)
        { }

        public IEnumerable<DysfunctionTranslation> GetAllDysfunctionsByLanguage(int languageId)
        {
            return GetAll(filter: x => x.LanguageId == languageId, orderBy: x => x.OrderBy(c => c.DysfunctionId), includeProperties: x => x.Dysfunction);
        }
    }
}
