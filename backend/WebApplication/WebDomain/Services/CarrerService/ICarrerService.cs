using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 8:03 13:08:2022
    /// Service xử lý  ngành nghề
    /// </summary>
    public interface ICarrerService
    {
        /// <summary>
        /// lấy danh sách ngành nghề
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllCarrer();
        /// <summary>
        /// danh sách người dùng theo tên
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> GetCarrerByName(string search);

    }
}
