using DAL.Data;
using DAL.Models;
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
            return GetAll(x => x.TeamId == teamId);
        }

        public Teamscan UpdateScores(Teamscan teamscan)
        {
            var entry = _context.Entry(teamscan);
            entry.Property(x => x.ScoreTrust).IsModified = true;
            entry.Property(x => x.ScoreConflict).IsModified = true;
            entry.Property(x => x.ScoreCommitment).IsModified = true;
            entry.Property(x => x.ScoreAccountability).IsModified = true;
            entry.Property(x => x.ScoreResults).IsModified = true;

            return entry.Entity;
        }
    }
}
