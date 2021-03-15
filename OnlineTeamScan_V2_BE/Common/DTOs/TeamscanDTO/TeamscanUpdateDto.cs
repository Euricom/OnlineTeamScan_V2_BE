using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.TeamscanDTO
{
    public class TeamscanUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal ScoreTrust { get; set; }
        public decimal ScoreConflict { get; set; }
        public decimal ScoreCommitment { get; set; }
        public decimal ScoreAccountability { get; set; }
        public decimal ScoreResults { get; set; }
    }
}
