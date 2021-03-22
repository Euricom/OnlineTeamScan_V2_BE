using Common.DTOs.InterpretationTranslationDTO;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.InterpretationTranslationRepositories
{
    public class InterpretationTranslationRepository : GenericRepository<InterpretationTranslation>, IInterpretationTranslationRepository
    {
        public InterpretationTranslationRepository(OnlineTeamScanContext context) : base(context)
        { }

        public InterpretationTranslation GetInterpretationTranslationByLanguage(int id, int languageId)
        {
            return GetAll(x => x.InterpretationId == id && x.LanguageId == languageId).FirstOrDefault();
        }
    }
}
