using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.InterpretationTranslationRepositories
{
    public interface IInterpretationTranslationRepository : IGenericRepository<InterpretationTranslation>
    {
        public InterpretationTranslation GetInterpretationTranslationByLanguage(int id, int languageId);
    }
}
