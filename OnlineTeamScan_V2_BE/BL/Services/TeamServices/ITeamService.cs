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
        public TeamReadDto GetTeamIncludingTeamMembersById(int id);
        public IEnumerable<TeamReadDto> GetAllTeams();
        public IEnumerable<TeamReadDto> GetAllTeamsIncludingTeamscans(int userId);
        public IEnumerable<TeamReadDto> GetAllTeamsIncludingTeamMembers(int userId);
        public IEnumerable<TeamReadDto> GetAllTeamsByUser(int userId);
        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto);
        public TeamReadDto UpdateTeamName(TeamUpdateDto teamUpdateDto);
        public void DeleteTeam(int id);
    }
}
