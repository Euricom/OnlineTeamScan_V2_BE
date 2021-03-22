using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.InterpretationRepositories
{
    public class InterpretationRepository : GenericRepository<Interpretation>, IInterpretationRepository
    {
        public InterpretationRepository(OnlineTeamScanContext context) : base(context)
        { }

        public Interpretation GetInterpretationByLevelAndDysfunction(int levelId, int dysfunctionId)
        {
            return GetAll(x => x.DysfunctionId == dysfunctionId && x.LevelId == levelId).FirstOrDefault();
        }
    }
}
