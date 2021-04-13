using Common.DTOs.DysfunctionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.QuestionDTO
{
    public class QuestionReadDto
    {
        public int Id { get; set; }
        public byte Number { get; set; }

        public int DysfunctionId { get; set; }
    }
}
