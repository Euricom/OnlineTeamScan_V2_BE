using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LevelTranslation
    {
        public int LanguageId { get; set; }
        public int LevelId { get; set; }
        public string Name { get; set; }

        public Language Language { get; set; }
        public Level Level { get; set; }
    }
}
