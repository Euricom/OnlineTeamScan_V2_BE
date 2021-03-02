using DAL.Models;
using DAL.Repositories.MockRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MocksController : ControllerBase
    {
        private readonly MockRepository _repository = new MockRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetAll()
        {
            var list = _repository.GetAll();
            return Ok(list);
        }
    }
}
