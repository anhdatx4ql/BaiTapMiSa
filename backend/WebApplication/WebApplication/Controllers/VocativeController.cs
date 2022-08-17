using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocativeController : ControllerBase
    {
        private readonly IVocativeService _vocative;
        public VocativeController(IVocativeService vocative)
        {
            _vocative = vocative;
        }

        [HttpGet]
        public async Task<ReponsitoryModel> GetAll()
        {
            return await _vocative.GetAll();
        }

        [HttpGet("{name}")]
        public async Task<ReponsitoryModel> GetAllByName(string name)
        {
            return await _vocative.GetAllByName(name);
        }

    }
}
