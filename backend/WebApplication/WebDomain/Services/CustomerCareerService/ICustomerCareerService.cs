using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 8:03 13:08:2022
    /// Service xử lý  ngành nghề liên quan đến khách hàng
    /// </summary>
    public interface ICustomerCareerService
    {
        /// <summary>
        /// lấy danh sách ngành nghề
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();


        /// <summary>
        /// danh sách người dùng theo tên
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> GetByName(string search);

        /// <summary>
        /// Tạo mới ngành nghề khách hàng
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> Create(CreateCustomerCareerModel[] models);
    }
}
