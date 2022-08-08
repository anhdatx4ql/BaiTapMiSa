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
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _field;
        public FieldController(IFieldService field)
        {
            _field = field;
        }

        [HttpGet("getAllIField")]
        public async Task<IActionResult> getAllIField()
        {
            return Ok(await _field.getAllField());
        }

        [HttpGet("GetFieldsByName/{name}")]
        public async Task<IActionResult> GetFieldsByName(string name)
        {
            return Ok(await _field.getFieldsByName(name));
        }

        [HttpGet("GetFieldById/{id}")]
        public async Task<IActionResult> GetFieldById(string id)
        {
            return Ok(await _field.getFieldById(id));
        }
    }
}
