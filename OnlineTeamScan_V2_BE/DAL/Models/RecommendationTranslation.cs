using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RecommendationTranslation
    {
        public int LanguageId { get; set; }
        public int RecommendationId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Language Language { get; set; }
        public Recommendation Recommendation { get; set; }
    }
}
