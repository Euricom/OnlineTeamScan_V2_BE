using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.QuestionTranslationRepositories
{
    public interface IQuestionTranslationRepository : IGenericRepository<QuestionTranslation>
    {
        public IEnumerable<QuestionTranslation> GetAllQuestionsByLanguage(int languageId);
    }
}
