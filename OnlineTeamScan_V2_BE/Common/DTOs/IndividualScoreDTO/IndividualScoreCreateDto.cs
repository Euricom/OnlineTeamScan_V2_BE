using Common.DTOs.AnswerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.IndividualScoreDTO
{
    public class IndividualScoreCreateDto
    {
        public int TeamMemberId { get; set; }
        public int TeamscanId { get; set; }
        public decimal ScoreTrust { get; set; }
        public decimal ScoreConflict { get; set; }
        public decimal ScoreCommitment { get; set; }
        public decimal ScoreAccountability { get; set; }
        public decimal ScoreResults { get; set; }
    }
}
