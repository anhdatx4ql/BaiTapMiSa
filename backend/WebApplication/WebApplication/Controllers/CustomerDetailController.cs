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
    public class CustomerDetailController : ControllerBase
    {
        private readonly ICustomerDetailService _customerDetail;
        public CustomerDetailController(ICustomerDetailService customerDetail)
        {
            _customerDetail = customerDetail;
        }



        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Lấy danh sách ngành nghề khách hàng theo CustomerId
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet("{searchCustomerId}")]
        public async Task<ReponsitoryModel> GetCarrersByName(string searchCustomerId)
        {
            return await _customerDetail.GetsByCustomerId(searchCustomerId);
        }


    }
}
