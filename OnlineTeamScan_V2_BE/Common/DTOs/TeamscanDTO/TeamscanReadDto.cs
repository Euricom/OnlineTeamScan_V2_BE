using Common.DTOs.TeamDTO;
using Common.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.TeamscanDTO
{
    public class TeamscanReadDto
    {
        public int Id { get; set; }
        public UserReadDto StartedBy { get; set; }
        public TeamReadDto Team { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? ScoreTrust { get; set; }
        public decimal? ScoreConflict { get; set; }
        public decimal? ScoreCommitment { get; set; }
        public decimal? ScoreAccountability { get; set; }
        public decimal? ScoreResults { get; set; }
    }
}
