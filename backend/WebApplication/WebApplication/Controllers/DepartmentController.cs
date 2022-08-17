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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _dapart;
        public DepartmentController(IDepartmentService dapart)
        {
            _dapart = dapart;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách ngành nghề
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ReponsitoryModel> GetAll()
        {
            return await _dapart.GetAll();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách ngành nghề theo tên
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet("{search}")]
        public async Task<ReponsitoryModel> GetsByName(string search)
        {
            return await _dapart.GetAllByName(search);
        }

    }
}
