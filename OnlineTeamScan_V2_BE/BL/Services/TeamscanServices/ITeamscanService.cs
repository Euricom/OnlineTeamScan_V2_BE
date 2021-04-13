using Common.DTOs.TeamscanDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamscanServices
{
    public interface ITeamscanService
    {
        public TeamscanReadDto GetTeamscanById(int id);
        public IEnumerable<TeamscanReadDto> GetAllTeamscansByTeam(int teamId);
        public TeamscanReadDto GetPreviousTeamscan(int id);
    }
}
