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

        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeams()
        {
            return Ok(_service.GetAllTeams());
        }

        [HttpGet("teamscans/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsWithTeamscans(int userId)
        {
            return Ok(_service.GetAllTeamsWithTeamscans(userId));
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

            var team = _service.AddTeam(teamCreateDto);
            return CreatedAtAction(nameof(GetTeamById), new { Id = team.Id }, team);
        }

        [HttpPut]
        public ActionResult<TeamReadDto> UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            if (teamUpdateDto == null)
                return BadRequest();

            return Ok(_service.UpdateTeam(teamUpdateDto));
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
