using BL.Services.TeamMemberServices;
using Common.DTOs.TeamMemberDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly ITeamMemberService _service;

        public TeamMembersController(ITeamMemberService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<TeamMemberReadDto> GetTeamMemberById(int id)
        {
            var teamMember = _service.GetTeamMemberById(id);

            if (teamMember != null)
                return Ok(teamMember);

            return NotFound();
        }

        [HttpGet("team/{teamId}")]
        public ActionResult<IEnumerable<TeamMemberReadDto>> GetAllTeamMembersByTeam(int teamId)
        {
            return Ok(_service.GetAllTeamMembersByTeam(teamId));
        }

        [HttpPost]
        public ActionResult<TeamMemberReadDto> AddTeamMember(TeamMemberCreateDto teamMemberCreateDto)
        {
            if (teamMemberCreateDto == null)
                return BadRequest();

            try
            {
                var teamMember = _service.AddTeamMember(teamMemberCreateDto);
                return CreatedAtAction(nameof(GetTeamMemberById), new { Id = teamMember.Id }, teamMember);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPut]
        public ActionResult<TeamMemberReadDto> UpdateTeamMember(TeamMemberUpdateDto teamMemberUpdateDto)
        {
            if (teamMemberUpdateDto == null)
                return BadRequest();

            try
            {
                return Ok(_service.UpdateTeamMember(teamMemberUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTeamMember(int id)
        {
            var teamMember = _service.GetTeamMemberById(id);

            if (teamMember == null)
                return NotFound();

            _service.DeleteTeamMember(id);
            return NoContent();
        }
    }
}
