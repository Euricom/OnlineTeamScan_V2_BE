using DAL.Data;
using DAL.Models;
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

        public IEnumerable<IndividualScore> GetAllByTeamscan(int teamscanId)
        {
            return GetAll(filter: i => i.TeamscanId == teamscanId);
        }
    }
}
