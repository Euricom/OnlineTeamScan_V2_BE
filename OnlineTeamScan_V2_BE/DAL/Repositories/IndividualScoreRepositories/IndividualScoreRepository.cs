using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IndividualScoreRepositories
{
    public class IndividualScoreRepository : GenericRepository<IndividualScore>, IIndividualScoreRepository
    {
        public IndividualScoreRepository(OnlineTeamScanContext context) : base(context)
        { }

        public IndividualScore GetIndividualScoreByIdIncludingTeamscan(Guid id)
        {
            return _dbSet.Include(x => x.Teamscan.StartedBy).Include(x => x.Teamscan.Team).Where(score => score.Id == id).FirstOrDefault();
        }

        public IndividualScore GetIndividualScoreById(Guid id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public IEnumerable<IndividualScore> GetAllAnsweredByTeamscan(int teamscanId)
        {
            return GetAll(filter: i => i.TeamscanId == teamscanId && i.HasAnswered == true);
        }

        public IndividualScore UpdateIndividualScore(IndividualScore individualScore)
        {
            var entry = _context.Entry(individualScore);
            entry.Property(x => x.ScoreTrust).IsModified = true;
            entry.Property(x => x.ScoreCommitment).IsModified = true;
            entry.Property(x => x.ScoreConflict).IsModified = true;
            entry.Property(x => x.ScoreAccountability).IsModified = true;
            entry.Property(x => x.ScoreResults).IsModified = true;
            entry.Property(x => x.HasAnswered).IsModified = true;

            return entry.Entity;
        }

        public IEnumerable<IndividualScore> GetAllIndividualScoresByTeamscanWithTeamMembers(int teamscanId)
        {
            return _dbSet.Include(individualScore => individualScore.TeamMember).Where(individualScore => individualScore.TeamscanId == teamscanId);
        }
    }
}
