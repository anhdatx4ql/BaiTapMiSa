using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 11:23 13/08/2022
    /// Service xử lý bảng phòng ban
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Createa Time: 11:22 13/08/2022
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Createa Time: 11:22 13/08/2022
        /// Lấy danh sách phòng ban theo tên
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
