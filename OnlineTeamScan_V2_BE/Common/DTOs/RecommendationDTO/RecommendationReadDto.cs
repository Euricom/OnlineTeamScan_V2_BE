using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.RecommendationDTO
{
    public class RecommendationReadDto
    {
        public int Id { get; set; }
        public int DysfunctionId { get; set; }
        public string Link { get; set; }
    }
}
