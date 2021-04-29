using Common.DTOs.InterpretationTranslationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.InterpretationTranslationServices
{
    public interface IInterpretationTranslationService
    {
        public IEnumerable<InterpretationTranslationReadDto> GetAllInterpretationTranslationsByLevelAndDysfunction(int languageId, int teamscanId);
    }
}
