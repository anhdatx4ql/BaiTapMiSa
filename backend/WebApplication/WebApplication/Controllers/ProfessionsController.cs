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
    public class ProfessionsController : ControllerBase
    {
        private readonly IProfessionsService _pro;
        public ProfessionsController(IProfessionsService pro)
        {
            _pro = pro;
        }


        [HttpGet("getAllProfessions")]
        public async Task<IActionResult> getAllProfessions()
        {
            return Ok(await _pro.getAllProfessions());
        }

        [HttpGet("GetProfessionsByName/{name}")]
        public async Task<IActionResult> GetProfessionsByName(string name)
        {
            return Ok(await _pro.getProfessionsByName(name));
        }

        [HttpGet("GetProfessionsById/{id}")]
        public async Task<IActionResult> GetProfessionsById(string id)
        {
            return Ok(await _pro.getProfessionById(id));
        }
    }
}
