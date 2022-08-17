using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain;

namespace WebApplication.Controllers
{
    [ApiController]
    public class CarrerController : ControllerBase
    {
        private readonly ICarrerService _carrer;
        public CarrerController(ICarrerService carrer)
        {
            _carrer = carrer;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách ngành nghề
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ReponsitoryModel> GetCarrers()
        {
            return await _carrer.GetAllCarrer();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách ngành nghề theo tên
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/{search}")]
        public async Task<ReponsitoryModel> GetCarrersByName(string search)
        {
            return await _carrer.GetCarrerByName(search);
        }

    }
}
