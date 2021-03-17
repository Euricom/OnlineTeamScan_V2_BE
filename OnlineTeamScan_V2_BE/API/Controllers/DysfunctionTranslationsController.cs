using BL.Services.DysfunctionTranslationServices;
using Common.DTOs.DysfunctionTranslationDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DysfunctionTranslationsController : ControllerBase
    {
        private readonly IDysfunctionTranslationService _service;

        public DysfunctionTranslationsController(IDysfunctionTranslationService service)
        {
            _service = service;
        }

        [HttpGet("language/{languageId}")]
        public ActionResult<IEnumerable<DysfunctionTranslationReadDto>> GetAllDysfunctionsByLanguage(int languageId)
        {
            return Ok(_service.GetAllDysfunctionsByLanguage(languageId));
        }        
    }
}
