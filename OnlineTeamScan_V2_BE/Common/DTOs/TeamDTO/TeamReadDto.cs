using Common.DTOs.TeamMemberDTO;
using Common.DTOs.TeamscanDTO;
using Common.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.TeamDTO
{
    public class TeamReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastTeamscan { get; set; }
        public bool IsTeamscanActive { get; set; }

        public UserReadDto Teamleader { get; set; }
        public ICollection<TeamMemberReadDto> TeamMembers { get; set; }
        public ICollection<TeamscanReadDto> Teamscans { get; set; }
    }
}
