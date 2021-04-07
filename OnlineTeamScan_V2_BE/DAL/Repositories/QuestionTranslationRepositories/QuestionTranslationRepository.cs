using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.QuestionTranslationRepositories
{
    public class QuestionTranslationRepository : GenericRepository<QuestionTranslation>, IQuestionTranslationRepository
    {
        public QuestionTranslationRepository(OnlineTeamScanContext context) : base(context)
        { }

        public IEnumerable<QuestionTranslation> GetAllQuestionsByLanguage(int languageId)
        {
            return GetAll(filter: x => x.LanguageId == languageId, orderBy: x => x.OrderBy(c => c.Question.Number), includeProperties: x => x.Question);
        }
    }
}
