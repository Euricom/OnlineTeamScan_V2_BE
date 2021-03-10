using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class IndividualScore
    {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        public int TeamscanId { get; set; }
        public decimal ScoreTrust { get; set; }
        public decimal ScoreConflict { get; set; }
        public decimal ScoreCommitment { get; set; }
        public decimal ScoreAccountability { get; set; }
        public decimal ScoreResults { get; set; }

        public TeamMember TeamMember { get; set; }
        public Teamscan Teamscan { get; set; }
    }
}
