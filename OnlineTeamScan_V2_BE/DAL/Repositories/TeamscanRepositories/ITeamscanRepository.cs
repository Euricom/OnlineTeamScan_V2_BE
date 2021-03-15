using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamscanRepositories
{
    public interface ITeamscanRepository : IGenericRepository<Teamscan, TeamscanReadDto, object, object>
    {
        public TeamscanReadDto UpdateScores(TeamscanUpdateDto teamscanUpdateDto);
    }
}
