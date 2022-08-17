using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain;
using WebInfrastructure;

namespace WebApplication.Controllers
{

    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customer;
        private readonly IDapperRepository _dapper;
        public CustomersController(ICustomerService customer, IDapperRepository dapper)
        {
            _customer = customer;
            _dapper= dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Result api lấy thông tin của customer
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ReponsitoryModel> GetAllCustomer()
        {
            return await _customer.GetAllCustomer();
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Result api lấy thông tin của customer bằng tên
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/{search}")]
        public async Task<ReponsitoryModel> GetCustomerBySearch(string search)
        {
            return await _customer.GetCustomerByFullName(search);
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Result api lấy thông tin của customer
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ReponsitoryModel> CreateCustomer([FromBody] CreateCustomerModel model)
        {
            return await _customer.CreateCustomer(model);
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - cập nhật thông tin customer
        /// DateTime: 13:41 12/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<ReponsitoryModel> UpdateCustomer([FromBody] UpdateCustomerModel model,string id)
        {
            return await _customer.UpdateCustomer(model,id);
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Xóa mềm bản ghi bằng cách chuyển isDelete = true
        /// DateTime: 13:41 12/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ReponsitoryModel> DeleteCustomer(string[] id)
        {
            return await _customer.DeleteCustomer(id);
        }

  
    }
}
