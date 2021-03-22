using Common.DTOs.TeamMemberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamMemberServices
{
    public interface ITeamMemberService
    {
        public TeamMemberReadDto GetTeamMemberById(int id);
        public IEnumerable<TeamMemberReadDto> GetAllTeamMembersByTeam(int teamId);
        public TeamMemberReadDto AddTeamMember(TeamMemberCreateDto teamMemberCreateDto);
        public TeamMemberReadDto UpdateTeamMember(TeamMemberUpdateDto teamMemberUpdateDto);
        public void DeleteTeamMember(int id);
    }
}
