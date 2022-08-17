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
    public class SourceController : ControllerBase
    {
        private readonly ISourceService _FieldService;
        public SourceController(ISourceService FieldService)
        {
            _FieldService = FieldService;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách nguồn gốc
        /// DateTime: 6:12 15/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ReponsitoryModel> GetAll()
        {
            return await _FieldService.GetAll();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách nguồn gốc theo tên
        /// DateTime: 6:12 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet("{search}")]
        public async Task<ReponsitoryModel> GetsByName(string search)
        {
            return await _FieldService.GetAllByName(search);
        }
    }
}
