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
    public class VocativeController : ControllerBase
    {
        private readonly IVocativeService _vocative;
        public VocativeController(IVocativeService vocative)
        {
            _vocative = vocative;
        }


        [HttpGet("getAllIVocative")]
        public async Task<IActionResult> getAllIVocative()
        {
            return Ok(await _vocative.getAllVocative());
        }

        [HttpGet("GetVocativesByName/{name}")]
        public async Task<IActionResult> GetVocativesByName(string name)
        {
            return Ok(await _vocative.getVocativesByName(name));
        }

        [HttpGet("GetVocativeById/{id}")]
        public async Task<IActionResult> GetVocativeById(string id)
        {
            return Ok(await _vocative.getVocativeById(id));
        }

    }
}
