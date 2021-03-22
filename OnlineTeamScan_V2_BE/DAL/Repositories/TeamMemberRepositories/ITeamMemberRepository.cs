using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamMemberRepositories
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        public IEnumerable<TeamMember> GetAllTeamMembersByTeam(int teamId);
        public TeamMember UpdateTeamMember(TeamMember teamMember);
    }
}
