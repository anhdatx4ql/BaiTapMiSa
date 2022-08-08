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
    public class PotentialController : ControllerBase
    {
        private readonly IPotentialService _poten;
        public PotentialController(IPotentialService poten)
        {
            _poten = poten;
        }

        [HttpGet("getAllPotential")]
        public async Task<IActionResult> getAllPotential()
        {
            return Ok(await _poten.getAllPotential());
        }

        [HttpGet("GetPotentialsByName/{name}")]
        public async Task<IActionResult> GetPotentialsByName(string name)
        {
            return Ok(await _poten.getPotentialsByName(name));
        }

        [HttpGet("GetPotentialById/{id}")]
        public async Task<IActionResult> GetPotentialById(string id)
        {
            return Ok(await _poten.getPotentialById(id));
        }
    }
}
