using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IndividualScoreRepositories
{
    public interface IIndividualScoreRepository : IGenericRepository<IndividualScore, IndividualScoreReadDto, IndividualScoreCreateDto, object>
    {
        public IEnumerable<IndividualScoreReadDto> GetAllByTeamscan(int teamscanId);
    }
}
