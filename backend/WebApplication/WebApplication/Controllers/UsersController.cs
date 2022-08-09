using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using WebDomain.Interfaces;
using WebDomain.Models;
using WebDomain.Models.UserModel;
using WebInfrastructure.Entities;
using WebInfrastructure.Repositories;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;
        public UsersController(IUserService user)
        {
            _user = user;
        }

        // lấy tất cả các user trong bảng
        [HttpGet("GetUsers")]
        public async Task<IActionResult> getAllUser()
        {

             return Ok( await _user.getAllUser());

        }

        //lấy tất cả các user có tên trong bảng
       [HttpGet("GetUsersByName/{name}")]
        public async Task<IActionResult> getAllUserByName(string name)
        {
            return Ok(await _user.getAllUserByName(name));

        }

        // lấy user chứa Id
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await _user.GetByIdAsync(id));
        }


        // lấy user chứa Id
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUsersModel model)
        {
            return Ok(await _user.CreateUserAsync(model));
        }


        // lấy user chứa Id
        [HttpPut("UpdateUserById/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserModel model,string id)
        {
            return Ok(await _user.UpdateUser(model,id));
        }
        
        // xóa user
        [HttpPut("DeleteUserById/{id}")]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            return Ok(await _user.DeleteUser(id));
        }
        


     
    }
}
