using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamscanRepositories
{
    public interface ITeamscanRepository : IGenericRepository<Teamscan>
    {
        public Teamscan GetFinishedTeamscanById(int id, int userId);
        public Teamscan UpdateScores(Teamscan teamscan);  
        public IEnumerable<Teamscan> GetAllTeamscansByTeam(int teamId);
        public Teamscan GetPreviousTeamscan(int teamId, int teamNumber);
        public int? GetLatestTeamscanNumber(int teamId);
    }
}
