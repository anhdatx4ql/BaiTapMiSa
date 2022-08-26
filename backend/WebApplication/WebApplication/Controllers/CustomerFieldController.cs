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
    public class CustomerFieldController : ControllerBase
    {
        private readonly ICustomerFieldService _customerFiled;
        public CustomerFieldController(ICustomerFieldService customerFiled)
        {
            _customerFiled = customerFiled;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 3:21 15/08/2022
        /// function: lấy danh sách lĩnh vực khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ReponsitoryModel> GetsCustomerCareer()
        {
            return await _customerFiled.GetAll();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 3:21 15/08/2022
        /// function: lấy danh sách lĩnh vực khách hàng theo tên lĩnh vực
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{search}")]
        public async Task<ReponsitoryModel> GetsCustomerCareer(string search)
        {
            return await _customerFiled.GetByName(search);
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 3:21 15/08/2022
        /// function: thêm lĩnh vực khách hàng
        /// </summary>
        /// <param name="Models"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ReponsitoryModel> CreateAsync([FromBody] CreateCustomerFieldModel[] Models)
        {
            return await _customerFiled.Create(Models);
        }
    }
}
