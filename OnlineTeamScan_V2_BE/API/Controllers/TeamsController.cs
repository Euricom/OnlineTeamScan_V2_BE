using BL.Services.TeamServices;
using Common.DTOs.TeamDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamsController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<TeamReadDto> GetTeamById(int id)
        {
            var team = _service.GetTeamById(id);

            if (team != null)
                return Ok(team);

            return NotFound();
        }

        [HttpGet("members/{id}")]
        public ActionResult<TeamReadDto> GetTeamIncludingTeamMembersById(int id)
        {
            var team = _service.GetTeamIncludingTeamMembersById(id);

            if (team != null)
                return Ok(team);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeams()
        {
            return Ok(_service.GetAllTeams());
        }

        [HttpGet("teamscans/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsIncludingTeamscans(int userId)
        {
            return Ok(_service.GetAllTeamsIncludingTeamscans(userId));
        }

        [HttpGet("teammembers/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsIncludingTeamMembers(int userId)
        {
            return Ok(_service.GetAllTeamsIncludingTeamMembers(userId));
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsByUser(int userId)
        {
            return Ok(_service.GetAllTeamsByUser(userId));
        }

        [HttpPost]
        public ActionResult<TeamReadDto> AddTeam(TeamCreateDto teamCreateDto)
        {
            
            if (teamCreateDto == null)
                return BadRequest();

            try
            {
                var team = _service.AddTeam(teamCreateDto);
                return CreatedAtAction(nameof(GetTeamById), new { Id = team.Id }, team);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<TeamReadDto> UpdateTeamName(TeamUpdateDto teamUpdateDto)
        {
            if (teamUpdateDto == null)
                return BadRequest();

            try
            {
                return Ok(_service.UpdateTeamName(teamUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTeam(int id)
        {
            var team = _service.GetTeamById(id);

            if (team == null)
                return NotFound();

            _service.DeleteTeam(id);
            return NoContent();
        }
    }
}
