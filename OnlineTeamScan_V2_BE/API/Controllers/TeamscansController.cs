using BL.Services.TeamscanServices;
using Common.DTOs.TeamDTO;
using Common.DTOs.TeamMemberDTO;
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

        [HttpGet("finished/{userId}/{id}")]
        public ActionResult<TeamscanReadDto> GetFinishedTeamscanById(int userId, int id)
        {
            var teamscan = _service.GetFinishedTeamscanById(id, userId);

            if (teamscan != null)
                return Ok(teamscan);

            return NotFound();
        }

        [HttpGet("previous/{userId}/{teamscanId}")]
        public ActionResult<TeamscanReadDto> GetPreviousTeamscan(int userId, int teamscanId)
        {
            var teamscan = _service.GetPreviousTeamscan(teamscanId);

            if (teamscan != null)
                return Ok(teamscan);

            return Ok(_service.GetFinishedTeamscanById(teamscanId, userId));
        }

        [HttpGet("{id}")]
        public ActionResult<TeamscanReadDto> GetTeamscanById(int id)
        {
            var teamscan = _service.GetTeamscanById(id);

            if (teamscan != null )
                return Ok(teamscan);

            return NotFound();
        }

        [HttpGet("team/{teamId}")]
        public ActionResult<IEnumerable<TeamscanReadDto>> GetAllTeamscansByTeam(int teamId)
        {
            return Ok(_service.GetAllTeamscansByTeam(teamId));
        }

        [HttpPost("{startedById}/{teamId}")]
        public ActionResult<TeamReadDto> AddTeamscan(int startedById, int teamId)
        {
            if (startedById == 0 || teamId == 0) return BadRequest();

            try
            {
                var updatedTeam = _service.AddTeamscan(startedById, teamId);
                return Ok(updatedTeam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remind/{individualScoreId}")]
        public ActionResult RemindTeamscan(Guid individualScoreId)
        {
            if (individualScoreId == Guid.Empty) return BadRequest();

            try
            {
                _service.RemindTeamscan(individualScoreId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
