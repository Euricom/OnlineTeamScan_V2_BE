using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class InterpretationTranslation
    {
        public int LanguageId { get; set; }
        public int InterpretationId { get; set; }
        public string Text { get; set; }

        public Language Language { get; set; }
        public Interpretation Interpretation { get; set; }
    }
}
