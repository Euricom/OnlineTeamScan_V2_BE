using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamscanRepositories
{
    public class TeamscanRepository : GenericRepository<Teamscan>, ITeamscanRepository
    {
        public TeamscanRepository(OnlineTeamScanContext context) : base(context)
        { }

        public IEnumerable<Teamscan> GetAllTeamscansByTeam(int teamId)
        {
            return GetAll(x => x.TeamId == teamId && x.EndDate != null);
        }

        public Teamscan UpdateScores(Teamscan teamscan)
        {
            var entry = _context.Entry(teamscan);
            entry.Property(x => x.ScoreTrust).IsModified = true;
            entry.Property(x => x.ScoreConflict).IsModified = true;
            entry.Property(x => x.ScoreCommitment).IsModified = true;
            entry.Property(x => x.ScoreAccountability).IsModified = true;
            entry.Property(x => x.ScoreResults).IsModified = true;
            entry.Property(x => x.EndDate).IsModified = true;

            return entry.Entity;
        }

        public Teamscan GetPreviousTeamscan(int teamId, int teamNumber)
        {
            return _dbSet.Where(x => x.TeamId == teamId && x.Number == teamNumber).FirstOrDefault();
        }

        public int? GetLatestTeamscanNumber(int teamId)
        {
            return _dbSet.Where(teamscan => teamscan.TeamId == teamId).Max(teamscan => (int?)teamscan.Number);
        }

        public Teamscan GetFinishedTeamscanById(int id, int userId)
        {
            return _dbSet.Include(teamscan => teamscan.Team).Include(teamscan => teamscan.StartedBy).Where(teamscan => teamscan.Id == id && teamscan.EndDate != null && teamscan.Team.TeamleaderId == userId).FirstOrDefault();
        }
    }
}
