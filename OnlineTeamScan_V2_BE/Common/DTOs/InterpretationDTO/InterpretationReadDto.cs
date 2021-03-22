using Common.DTOs.DysfunctionDTO;
using Common.DTOs.LevelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.InterpretationDTO
{
    public class InterpretationReadDto
    {
        public int Id { get; set; }

        public DysfunctionReadDto Dysfunction { get; set; }
        public LevelReadDto Level { get; set; }
    }
}
