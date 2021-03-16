using Common.DTOs.TeamDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamServices
{
    public interface ITeamService
    {
        public TeamReadDto GetTeamById(int id);
        public IEnumerable<TeamReadDto> GetAllTeams();
        public IEnumerable<TeamReadDto> GetAllTeamsWithTeamscans(int userId);
        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto);
        public TeamReadDto UpdateTeam(TeamUpdateDto teamUpdateDto);
        public void DeleteTeam(int id);
    }
}
