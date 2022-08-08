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
    public class RevenuesController : ControllerBase
    {
        private readonly IRevenuesService _revenue;
        public RevenuesController(IRevenuesService revenue)
        {
            _revenue = revenue;
        }


        [HttpGet("getAllRevenue")]
        public async Task<IActionResult> getAllRevenue()
        {
            return Ok(await _revenue.getAllRevenue());
        }

        [HttpGet("GetRevenuesByName/{name}")]
        public async Task<IActionResult> GetRevenuesByName(string name)
        {
            return Ok(await _revenue.getRevenuesByName(name));
        }

        [HttpGet("GetRevenueById/{id}")]
        public async Task<IActionResult> GetRevenueById(string id)
        {
            return Ok(await _revenue.getRevenueById(id));
        }
    }
}
