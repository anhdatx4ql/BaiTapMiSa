using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain.Interfaces;
using WebInfrastructure.Entities;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfBankController : ControllerBase
    {
        private readonly ITypeOfBankService _type;
        public TypeOfBankController(ITypeOfBankService type)
        {
            _type = type;
        }


        [HttpGet("GetAllTypeOfBank")]
        public async Task<IActionResult> GetAllTypeOfBank()
        {
            return Ok(await _type.getAllTypeOfBank());
        }

        [HttpGet("GetTypeOfBankByName/{name}")]
        public async Task<IActionResult> GetTypeOfBankByName(string name)
        {
            return Ok(await _type.getTypeOfBanksByName(name));
        }

        [HttpGet("GetTypeOfBankById/{id}")]
        public async Task<IActionResult> GetTypeOfBankById(string id)
        {
            return Ok(await _type.getTypeOfBankById(id));
        }

        [HttpPost("CreateOfBank")]
        public async Task<IActionResult> CreateOfBank([FromBody] TypeOfBank model)
        {
            return Ok(await _type.createTypeOfBank(model));
        }
    }
}
