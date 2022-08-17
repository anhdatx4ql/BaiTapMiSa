using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 15:33 14/08/2022
    /// Service xử lý  thông tin chi tiết khách hàng
    /// </summary>
    public interface ICustomerDetailService
    {

        /// <summary>
        /// lấy danh sách thông tin chi tiết khách hàng
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();


        /// <summary>
        /// danh sách thông tin chi tiết khách hàng theo tên
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> GetsByName(string search);

        /// <summary>
        /// danh sách thông tin chi tiết khách hàng theo CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> GetsByCustomerId(string CustomerId);
    }
}
