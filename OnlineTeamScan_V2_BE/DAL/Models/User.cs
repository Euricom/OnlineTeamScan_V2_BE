using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User : IdentityUser<int>
    {
        public int PreferredLanguageId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Language PreferredLanguage { get; set; }
    }
}
