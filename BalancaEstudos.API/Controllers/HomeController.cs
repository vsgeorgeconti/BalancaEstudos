using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BalancaEstudos.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("health-check")]
        public async Task<IActionResult> Get()
        {
            return Ok("API Ok!");
        }
    }
}