using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.DysfunctionTranslationRepositories
{
    public interface IDysfunctionTranslationRepository : IGenericRepository<DysfunctionTranslation>
    {
        public IEnumerable<DysfunctionTranslation> GetAllDysfunctionsByLanguage(int languageId);
    }
}
