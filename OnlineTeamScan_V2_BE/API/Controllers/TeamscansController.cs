using BL.Services.TeamscanServices;
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


        [HttpGet("team/{teamId}")]
        public ActionResult<IEnumerable<TeamscanReadDto>> GetAllTeamscansByTeam(int teamId)
        {
            return Ok(_service.GetAllTeamscansByTeam(teamId));
        }
    }
}
