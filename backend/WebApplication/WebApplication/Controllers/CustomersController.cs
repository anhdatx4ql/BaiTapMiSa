using Common;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Threading.Tasks;
using WebDomain;
using WebInfrastructure;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;

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
        /// - Result api lấy thông tin của customer
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/Paging")]
        public async Task<ReponsitoryModel> PagingCustomer(string keyword=null, int currentPageNumber=1, int pageSize=10)
        {
            return await _customer.PagingCustomer(keyword, currentPageNumber, pageSize);
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Result api lấy thông tin của customer
        /// DateTime: 10:25 11/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/PagingFilter")]
        public async Task<ReponsitoryModel> PagingFilterCustomer([FromBody] List<CustomerFilterModel> models, string keyword = null, int currentPageNumber = 1, int pageSize = 10)
        {
            return await _customer.PagingFilterCustomer(models, keyword, currentPageNumber, pageSize);
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
        [HttpPost]
        [Route("api/[controller]/DeleteMul")]
        public async Task<ReponsitoryModel> DeleteCustomer(List<Guid> ListString)
        {
            return await _customer.DeleteCustomer(ListString);
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Xóa mềm bản ghi bằng cách chuyển isDelete = true
        /// DateTime: 13:41 12/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetCode")]
        public async Task<ReponsitoryModel> GetCode()
        {
            return await _customer.GetCustomerCodeMax();
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Xóa mềm bản ghi bằng cách chuyển isDelete = true
        /// DateTime: 13:41 12/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/CheckExists")]
        public async Task<ReponsitoryModel> GetCode([FromBody] FormCheckExists model)
        {
            return await _customer.CheckExistColumn(model);
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Xóa mềm bản ghi bằng cách chuyển isDelete = true
        /// DateTime: 13:41 12/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/UpdateMul")]
        public async Task<ReponsitoryModel> UpdateMul([FromBody] UpdateCustomerMul model)
        {
            return await _customer.UpdateCustomerMul(model);
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// - Xóa mềm bản ghi bằng cách chuyển isDelete = true
        /// DateTime: 13:41 12/08/2022
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/ExportExcel")]
        public async Task<IActionResult> ExportExcel ([FromBody] List<Guid> models)
        {


            var fileContents = await _customer.ExportExcel(models);
            
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "ListCustomer-"+DateTime.Now.Ticks.ToString()+".xlsx"
            );

         
        }


    }
}
