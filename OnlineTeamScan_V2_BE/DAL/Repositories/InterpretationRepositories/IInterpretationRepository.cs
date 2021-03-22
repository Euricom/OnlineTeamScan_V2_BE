using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.InterpretationRepositories
{
    public interface IInterpretationRepository : IGenericRepository<Interpretation>
    {
        public Interpretation GetInterpretationByLevelAndDysfunction(int levelId, int dysfunctionId);
    }
}
