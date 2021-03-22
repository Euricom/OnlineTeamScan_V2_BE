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

        [HttpGet("{languageId}")]
        public ActionResult<IEnumerable<InterpretationTranslationReadDto>> GetAllInterpretationTranslationsByLevelAndDysfunctions(int languageId, [FromBody] List<InterpretationTranslationRequestDto> list)
        {
            return Ok(_service.GetAllInterpretationTranslationsByLevelAndDysfunctions(languageId, list));
        }
    }
}
