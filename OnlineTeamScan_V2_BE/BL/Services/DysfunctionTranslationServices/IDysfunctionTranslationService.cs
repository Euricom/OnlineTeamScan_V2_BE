using Common.DTOs.DysfunctionTranslationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.DysfunctionTranslationServices
{
    public interface IDysfunctionTranslationService
    {
        public IEnumerable<DysfunctionTranslationReadDto> GetAllDysfunctionsByLanguage(int languageId);
    }
}
