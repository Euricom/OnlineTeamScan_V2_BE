using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.TeamDTO
{
    public class TeamUpdateDto
    {
        public int Id { get; set; }
        public int TeamleaderId { get; set; }
        public string Name { get; set; }
        public DateTime? LastTeamScan { get; set; }
        public bool IsTeamscanActive { get; set; }
    }
}
