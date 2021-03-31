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

        public Team UpdateTeam(Team team)
        {
            var entry = _context.Entry(team);
            entry.Property(x => x.Name).IsModified = true;

            return entry.Entity;
        }
    }
}
