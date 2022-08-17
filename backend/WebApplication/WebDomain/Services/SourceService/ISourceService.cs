using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 19:33 13/08/2022
    /// Service xử lý bảng nguồn gốc tiềm năng
    /// </summary>
    public interface ISourceService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Createa Time: 11:22 13/08/2022
        /// Lấy danh sách nguồn gốc
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Createa Time: 11:22 13/08/2022
        /// Lấy danh sách nguồn gốc theo tên
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
