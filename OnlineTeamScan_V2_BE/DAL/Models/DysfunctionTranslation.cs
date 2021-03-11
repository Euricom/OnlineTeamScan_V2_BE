using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DysfunctionTranslation
    {
        public int LanguageId { get; set; }
        public int DysfunctionId { get; set; }
        public string Name { get; set; }


        public Language Language { get; set; }
        public Dysfunction Dysfunction { get; set; }
    }
}
