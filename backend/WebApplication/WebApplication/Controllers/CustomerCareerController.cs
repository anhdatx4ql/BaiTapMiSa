using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain;
using WebInfrastructure;
using static WebDomain.ContantsError;

namespace WebApplication.Controllers
{
    [ApiController]
    public class CustomerCareerController : ControllerBase
    {
        private readonly ICustomerCareerService _customerCarerr;
        public CustomerCareerController(ICustomerCareerService customerCarerr)
        {
            _customerCarerr = customerCarerr;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 3:21 15/08/2022
        /// function: lấy danh sách ngành nghề khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ReponsitoryModel> GetsCustomerCareer()
        {
            return await _customerCarerr.GetAll();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 3:21 15/08/2022
        /// function: lấy danh sách ngành nghề khách hàng theo tên ngành nghề
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/{search}")]
        public async Task<ReponsitoryModel> GetsCustomerCareer(string search)
        {
            return await _customerCarerr.GetByName(search);
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 3:21 15/08/2022
        /// function: thêm ngành nghề khách hàng
        /// </summary>
        /// <param name="Models"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ReponsitoryModel> CreateAsync([FromBody] CreateCustomerCareerModel[] Models)
        {
            return await _customerCarerr.Create(Models);
        }
    }
}
