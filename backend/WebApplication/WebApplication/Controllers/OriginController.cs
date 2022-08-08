using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginController : ControllerBase
    {
        private readonly IOriginService _origin;

        public OriginController(IOriginService origin)
        {
            _origin = origin;
        }



        [HttpGet("getAllOrigin")]
        public async Task<IActionResult> getAllOrigin()
        {
            return Ok(await _origin.getAllOrigin());
        }

        [HttpGet("GetOriginsByName/{name}")]
        public async Task<IActionResult> GetOriginsByName(string name)
        {
            return Ok(await _origin.getOriginsByName(name));
        }

        [HttpGet("GetOriginById/{id}")]
        public async Task<IActionResult> GetFieldById(string id)
        {
            return Ok(await _origin.getOriginById(id));
        }
    }
}
