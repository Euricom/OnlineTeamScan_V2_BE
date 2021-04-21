using BL.Services.TeamscanServices;
using Common.DTOs.TeamDTO;
using Common.DTOs.TeamscanDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamscansController : ControllerBase
    {
        private readonly ITeamscanService _service;

        public TeamscansController(ITeamscanService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<TeamscanReadDto> GetTeamscanById(int id)
        {
            var teamscan = _service.GetTeamscanById(id);

            if (teamscan != null)
                return Ok(teamscan);

            return NotFound();
        }

        [HttpGet("team/{teamId}")]
        public ActionResult<IEnumerable<TeamscanReadDto>> GetAllTeamscansByTeam(int teamId)
        {
            return Ok(_service.GetAllTeamscansByTeam(teamId));
        }

        [HttpGet("previous/{teamscanId}")]
        public ActionResult<TeamscanReadDto> GetPreviousTeamscan(int teamscanId)
        {
            var teamscan = _service.GetPreviousTeamscan(teamscanId);

            if (teamscan != null)
            {
                return Ok(teamscan);
            }

            return Ok(_service.GetTeamscanById(teamscanId));
        }

        [HttpPost("{startedById}/{teamId}")]
        public ActionResult<TeamReadDto> AddTeamscan(int startedById, int teamId)
        {
            if (startedById == 0 || teamId == 0) return BadRequest();

            try
            {
                var updatedTeam = _service.AddTeamscan(startedById, teamId);
                return CreatedAtAction(nameof(GetTeamscanById), new { Id = updatedTeam.Id }, updatedTeam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
