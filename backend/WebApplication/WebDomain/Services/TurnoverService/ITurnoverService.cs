using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 6:15 15/08/2022
    /// Service xử lý bảng doanh thu
    /// </summary>
    public interface ITurnoverService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 6:15 15/08/2022
        /// Lấy danh sách doanh thu
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 6:15 15/08/2022
        /// Lấy danh sách doanh thu theo tên
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
