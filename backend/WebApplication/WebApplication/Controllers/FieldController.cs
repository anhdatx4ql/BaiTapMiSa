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
    public class FieldController : ControllerBase
    {

        private readonly IFieldService _FieldService;
        public FieldController(IFieldService FieldService)
        {
            _FieldService = FieldService;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách lĩnh vực
        /// DateTime: 4:32 15/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ReponsitoryModel> GetAll()
        {
            return await _FieldService.GetAll();
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
            return await _FieldService.GetAllByName(search);
        }
    }
}
