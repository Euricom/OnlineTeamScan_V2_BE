using BL.Services.IndividualScoreServices;
using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualScoresController : ControllerBase
    {
        private readonly IIndividualScoreService _service;

        public IndividualScoresController(IIndividualScoreService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<IndividualScoreReadDto> GetIndividualScoreById(int id)
        {
            var individualScore = _service.GetIndividualScoreById(id);

            if (individualScore != null)
                return Ok(individualScore);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<IndividualScoreReadDto>> GetAllIndividualScores()
        {
            return Ok(_service.GetAllIndividualScores());
        }

        [HttpPost("{teamMemberId}/{teamscanId}")]
        public ActionResult<IndividualScoreReadDto> AddScore(int teamMemberId, int teamscanId, [FromBody] List<AnswerReadDto> list)
        {
            try
            {
                var individualScore = _service.AddIndividualScore(teamMemberId, teamscanId, list);
                _service.CalculateTeamscore(teamscanId);
                return CreatedAtAction(nameof(GetIndividualScoreById), new { Id = individualScore.Id }, individualScore);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }
    }
}
