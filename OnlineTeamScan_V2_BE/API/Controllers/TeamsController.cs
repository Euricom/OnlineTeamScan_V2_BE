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

        [HttpGet("full/{userId}/{id}")]
        public ActionResult<TeamReadDto> GetFullTeamById(int userId, int id)
        {
            var team = _service.GetFullTeamById(userId, id);

            if (team != null)
                return Ok(team);

            return NotFound();
        }

        [HttpGet("active/{userId}")]
        public ActionResult<TeamReadDto> GetAllActiveTeamsByUserId(int userId)
        {
            var listTeams = _service.GetAllActiveTeamsByUser(userId);

            if (listTeams != null)
                return Ok(listTeams);

            return NotFound();
        }

        [HttpGet("teamscans/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsByUserIncludingTeamscans(int userId)
        {
            return Ok(_service.GetAllTeamsByUserIncludingTeamscans(userId));
        }

        [HttpGet("teamscans/sorted/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsByUserIncludingTeamscansSorted(int userId)
        {
            return Ok(_service.GetAllTeamsByUserIncludingTeamscansSorted(userId));
        }

        [HttpGet("teammembers/{userId}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeamsByUserIncludingTeamMembers(int userId)
        {
            return Ok(_service.GetAllTeamsByUserIncludingTeamMembers(userId));
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
