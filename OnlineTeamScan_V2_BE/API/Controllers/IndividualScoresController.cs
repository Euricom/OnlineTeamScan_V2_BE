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

        [HttpGet("include/{id}")]
        public ActionResult<IndividualScoreReadDto> GetIndividualScoreByIdIncludingTeamscan(Guid id)
        {
            var individualScore = _service.GetIndividualScoreByIdIncludingTeamscan(id);

            if (individualScore != null)
                return Ok(individualScore);

            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<IndividualScoreReadDto> GetIndividualScoreById(Guid id)
        {
            var individualScore = _service.GetIndividualScoreById(id);

            if (individualScore != null)
                return Ok(individualScore);

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IndividualScoreReadDto> UpdateScore(Guid id, [FromBody] List<AnswerReadDto> list)
        {
            try
            {
                var updatedScore = _service.UpdateIndividualScore(id, list);
                return Ok(updatedScore);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
