using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IndividualScoreServices
{
    public interface IIndividualScoreService
    {
        public IndividualScoreReadDto GetIndividualScoreById(int id);
        public IEnumerable<IndividualScoreReadDto> GetAllIndividualScores();
        public IndividualScoreReadDto AddIndividualScore(int teamMemberId, int teamscanId, List<AnswerReadDto> list);
        public void CalculateTeamscore(int teamscanId);
    }
}
