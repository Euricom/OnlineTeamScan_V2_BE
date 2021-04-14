using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamRepositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(OnlineTeamScanContext context) : base(context)
        { }

        public Team GetTeamIncludingTeamMembersById(int id)
        {
            return _dbSet.Include(x => x.TeamMembers).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Team> GetAllTeamsByUser(int userId)
        {
            return GetAll(team => team.TeamleaderId == userId);
        }

        public IEnumerable<Team> GetAllTeamsIncludingTeamMembers(int userId)
        {
            return GetAll(filter: team => team.TeamleaderId == userId, includeProperties: x => x.TeamMembers);
        }

        public IEnumerable<Team> GetAllTeamsIncludingTeamscans(int userId)
        {
            return GetAll(filter: team => team.TeamleaderId == userId, includeProperties: x => x.Teamscans);
        }

        public Team UpdateTeamName(Team team)
        {
            var entry = _context.Entry(team);
            entry.Property(x => x.Name).IsModified = true;

            return entry.Entity;
        }

        public Team UpdateIsTeamscanActive(Team team)
        {
            team.IsTeamscanActive = true;
            var entry = _context.Entry(team);
            entry.Property(x => x.IsTeamscanActive).IsModified = true;

            return entry.Entity;
        }
    }
}
