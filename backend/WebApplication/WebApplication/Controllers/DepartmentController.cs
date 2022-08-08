using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain.Interfaces;
using WebDomain.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _depart;
        public DepartmentController(IDepartmentService depart)
        {
            _depart = depart;
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            return Ok(await _depart.getAllDepartment());
        }

        [HttpGet("GetDepartmentByName/{name}")]
        public async Task<IActionResult> GetDepartmentByName(string name)
        {
            return Ok(await _depart.getDepartmentsByName(name));
        }

        [HttpGet("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById(string id)
        {
            return Ok(await _depart.getDepartmentsById(id));
        }

    }
}
