using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.MockRepositories
{
    public class MockRepository : IMockRepository
    {
        public IEnumerable<Team> GetAll()
        {
            List<Team> list = new List<Team>
            {
                new Team{ Id=1, TeamName="Online Team Scan", LastTeamScan=DateTime.Today},
                new Team{ Id=2, TeamName="Team Smart Fridge", LastTeamScan=DateTime.MinValue},
                new Team{ Id=3, TeamName="Team Testing", LastTeamScan=DateTime.MaxValue}
            };

            return list;
        }
    }
}
