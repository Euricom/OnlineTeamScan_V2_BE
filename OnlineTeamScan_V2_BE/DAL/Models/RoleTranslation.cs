using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RoleTranslation
    {
        public int RoleId { get; set; }
        public int LanguageId { get; set; }
        public string Translation { get; set; }

        public Role Role { get; set; }
        public Language Language { get; set; }
    }
}
