using Common.DTOs.TeamDTO;
using Common.DTOs.TeamscanDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamscanServices
{
    public interface ITeamscanService
    {
        public TeamscanReadDto GetFinishedTeamscanById(int id, int userId);
        public TeamscanReadDto GetTeamscanById(int id);
        public IEnumerable<TeamscanReadDto> GetAllTeamscansByTeam(int teamId);
        public TeamscanReadDto GetPreviousTeamscan(int teamscanId);
        public TeamReadDto AddTeamscan(int startedById, int teamId);
        public void RemindTeamscan(Guid individualScoreId);
    }
}
