using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamRepositories
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        public Team GetTeamIncludingTeamMembersById(int id);
        public IEnumerable<Team> GetAllTeamsIncludingTeamscans(int userId);
        public IEnumerable<Team> GetAllTeamsIncludingTeamMembers(int userId);
        public IEnumerable<Team> GetAllTeamsByUser(int userId);
        public Team UpdateTeamName(Team team);
        public Team UpdateIsTeamscanActive(Team team);
    }
}
