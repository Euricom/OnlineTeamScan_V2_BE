using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TeamscanMember
    {
        public int TeamMemberId { get; set; }
        public int TeamscanId { get; set; }
        public bool HasAnswered { get; set; }


        public TeamMember TeamMember { get; set; }
        public Teamscan Teamscan { get; set; }
    }
}
