using BL.Services.InterpretationServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterpretationsController : ControllerBase
    {
        private readonly IInterpretationService _service;

        public InterpretationsController(IInterpretationService service)
        {
            _service = service;
        }
    }
}
