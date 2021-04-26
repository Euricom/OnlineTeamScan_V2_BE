using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamMemberRepositories
{
    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(OnlineTeamScanContext context) : base(context)
        { }

        public IEnumerable<TeamMember> GetAllActiveTeamMembersByTeam(int teamId)
        {
            return GetAll(teamMember => teamMember.TeamId == teamId && teamMember.IsActive == true);
        }

        public IEnumerable<TeamMember> GetAllTeamMembersByTeam(int teamId)
        {
            return GetAll(x => x.TeamId == teamId);
        }

        public TeamMember UpdateTeamMember(TeamMember teamMember)
        {
            var entry = _context.Entry(teamMember);
            entry.Property(x => x.Email).IsModified = true;
            entry.Property(x => x.Firstname).IsModified = true;
            entry.Property(x => x.Lastname).IsModified = true;
            entry.Property(x => x.IsActive).IsModified = true;

            return entry.Entity;
        }
    }
}
