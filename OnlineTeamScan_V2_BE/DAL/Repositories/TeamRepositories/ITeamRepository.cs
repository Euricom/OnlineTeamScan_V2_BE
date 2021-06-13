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
        public Team GetFullTeamById(int id);
        public Team GetTeamIncludingTeamMembersById(int id);
        public IEnumerable<Team> GetAllTeamsByUserIncludingTeamscans(int userId);
        public IEnumerable<Team> GetAllTeamsByUserIncludingTeamscansSorted(int userId);
        public IEnumerable<Team> GetAllTeamsByUserIncludingTeamMembers(int userId);
        public IEnumerable<Team> GetAllTeamsByUser(int userId);
        public IEnumerable<Team> GetAllActiveTeamsByUser(int userId);
        public Team UpdateTeamName(Team team);
        public Team UpdateIsTeamscanActive(Team team);
        public Team UpdateLastTeamscanOfTeam(Team team);
    }
}
