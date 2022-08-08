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
    public class UserFieldController : ControllerBase
    {
        private readonly IUserFieldService _userfiled;
        public UserFieldController(IUserFieldService userfiled)
        {
            _userfiled = userfiled;
        }

        [HttpGet("getAllUserField")]
        public async Task<IActionResult> getAllUserField()
        {
            return Ok(await _userfiled.getAllUserField());
        }

        [HttpGet("GetUserFieldByFieldName/{fieldName}")]
        public async Task<IActionResult> GetUserFieldByFieldName(string fieldName)
        {
            return Ok(await _userfiled.getUserFieldsByFieldName(fieldName));
        }

        [HttpGet("GetUserFieldByUserId/{UserId}")]
        public async Task<IActionResult> GetUserFieldByUserId(string UserId)
        {
            return Ok(await _userfiled.getUserFieldByUserId(UserId));
        }

        [HttpPost("CreateUserField")]
        public async Task<IActionResult> GetUserFieldByUserId([FromBody] User_Field model)
        {
            return Ok(await _userfiled.CreateUserField(model));
        }
    }
}
