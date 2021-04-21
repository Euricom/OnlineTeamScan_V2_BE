using Common.DTOs.QuestionTranslationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.QuestionTranslationServices
{
    public interface IQuestionTranslationService
    {
        public IEnumerable<QuestionTranslationReadDto> GetAllQuestionsByLanguage(int languageId);
    }
}
