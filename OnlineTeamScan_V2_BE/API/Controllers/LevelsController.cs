using BL.Services.LevelServices;
using Common.DTOs.LevelDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelService _service;

        public LevelsController(ILevelService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LevelReadDto>> GetAllLevels()
        {
            return Ok(_service.GetAllLevels());
        }
    }
}
