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
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleService _jobTitle;

        public JobTitleController(IJobTitleService jobTitle)
        {
            _jobTitle = jobTitle;
        }


        [HttpGet("getAllJobTitle")]
        public async Task<IActionResult> getAllJobTitle()
        {
            return Ok(await _jobTitle.getAllJobTitle());
        }

        [HttpGet("GetJobTitlesByName/{name}")]
        public async Task<IActionResult> GetFieldsByName(string name)
        {
            return Ok(await _jobTitle.getJobTitlesByName(name));
        }

        [HttpGet("GetJobTitleById/{id}")]
        public async Task<IActionResult> GetFieldById(string id)
        {
            return Ok(await _jobTitle.getJobTitleById(id));
        }

    }
}
