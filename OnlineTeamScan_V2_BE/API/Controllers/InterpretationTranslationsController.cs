using BL.Services.InterpretationTranslationServices;
using Common.DTOs.InterpretationTranslationDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterpretationTranslationsController : ControllerBase
    {
        private readonly IInterpretationTranslationService _service;

        public InterpretationTranslationsController(IInterpretationTranslationService service)
        {
            _service = service;
        }

        [HttpGet("{languageId}/{teamscanId}")]
        public ActionResult<IEnumerable<InterpretationTranslationReadDto>> GetAllInterpretationTranslationsByLevelAndDysfunction(int languageId, int teamscanId)
        {
            return Ok(_service.GetAllInterpretationTranslationsByLevelAndDysfunction(languageId, teamscanId));
        }
    }
}
