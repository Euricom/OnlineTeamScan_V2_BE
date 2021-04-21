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
        public IndividualScore GetIndividualScoreByIdIncludingTeamscan(Guid id);
        public IndividualScore GetIndividualScoreById(Guid id);
        public IEnumerable<IndividualScore> GetAllAnsweredByTeamscan(int teamscanId);
        public IndividualScore UpdateIndividualScore(IndividualScore individualScore);
    }
}
