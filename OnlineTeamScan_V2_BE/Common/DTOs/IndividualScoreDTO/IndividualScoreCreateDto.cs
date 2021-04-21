using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.IndividualScoreDTO
{
    public class IndividualScoreCreateDto
    {
        public Guid Id { get; set; }
        public int TeamMemberId { get; set; }
        public int TeamscanId { get; set; }
    }
}
