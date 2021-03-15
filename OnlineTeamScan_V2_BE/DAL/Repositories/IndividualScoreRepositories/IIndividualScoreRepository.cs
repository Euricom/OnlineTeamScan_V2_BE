using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IndividualScoreRepositories
{
    public interface IIndividualScoreRepository : IGenericRepository<IndividualScore>
    {
        public IEnumerable<IndividualScore> GetAllByTeamscan(int teamscanId);
    }
}
