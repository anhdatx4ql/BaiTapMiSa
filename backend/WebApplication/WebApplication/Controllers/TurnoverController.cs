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
    public class TurnoverController : ControllerBase
    {
        private readonly ITurnoverService _FieldService;
        public TurnoverController(ITurnoverService FieldService)
        {
            _FieldService = FieldService;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách doanh thu
        /// DateTime: 6:20 15/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ReponsitoryModel> GetAll()
        {
            return await _FieldService.GetAll();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách doanh thu theo tên
        /// DateTime: 6:20 15/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet("{search}")]
        public async Task<ReponsitoryModel> GetsByName(string search)
        {
            return await _FieldService.GetAllByName(search);
        }
    }
}
