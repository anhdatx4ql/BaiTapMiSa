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
    public class UserPotentialController : ControllerBase
    {
        private readonly IUserPotentialService _userpoten;
        public UserPotentialController(IUserPotentialService userpoten)
        {
            _userpoten = userpoten;
        }


        [HttpGet("getAllUserPotential")]
        public async Task<IActionResult> getAllUserPotential()
        {
            return Ok(await _userpoten.getAllUserPotential());
        }

        [HttpGet("GetUserPotentialdByPotentialName/{PotentialName}")]
        public async Task<IActionResult> GetUserPotentialdByPotentialName(string PotentialName)
        {
            return Ok(await _userpoten.getUserPotentialsByPotentialName(PotentialName));
        }

        [HttpGet("GetUserPotentialByUserId/{UserId}")]
        public async Task<IActionResult> GetUserPotentialByUserId(string UserId)
        {
            return Ok(await _userpoten.getUserPotentialByUserId(UserId));
        }

        [HttpPost("CreateUserPotential")]
        public async Task<IActionResult> CreateUserPotential([FromBody] User_Potential model)
        {
            return Ok(await _userpoten.CreateUserPotential(model));
        }

    }
}
