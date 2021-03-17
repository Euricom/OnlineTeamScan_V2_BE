using Common.DTOs.LevelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.LevelServices
{
    public interface ILevelService
    {
        public IEnumerable<LevelReadDto> GetAllLevels();
    }
}
