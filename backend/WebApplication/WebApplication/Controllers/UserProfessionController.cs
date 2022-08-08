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
    public class UserProfessionController : ControllerBase
    {
        private readonly IUserProfessionService _userpro;
        public UserProfessionController(IUserProfessionService userpro)
        {
            _userpro = userpro;
        }


        [HttpGet("getAllUserProfession")]
        public async Task<IActionResult> getAllUserProfession()
        {
            return Ok(await _userpro.getAllUserProfession());
        }

        [HttpGet("GetUserProfessionByProfessionName/{ProfessionName}")]
        public async Task<IActionResult> GetUserProfessionByProfessionName(string ProfessionName)
        {
            return Ok(await _userpro.getUserProfessionsByName(ProfessionName));
        }

        [HttpGet("GetUserProfessionByUserId/{UserId}")]
        public async Task<IActionResult> GetUserProfessionByUserId(string UserId)
        {
            return Ok(await _userpro.getUserProfessionByUserId(UserId));
        }

        [HttpPost("CreateUserProfession")]
        public async Task<IActionResult> CreateUserProfession([FromBody] User_Profession model)
        {
            return Ok(await _userpro.CreateUserProfession(model));
        }


    }
}
