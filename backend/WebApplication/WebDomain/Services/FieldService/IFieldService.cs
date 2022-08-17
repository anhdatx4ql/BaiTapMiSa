using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 4:22 15/08/2022
    /// function: Service xử lý bảng lĩnh vực
    /// </summary>
    public interface IFieldService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 4:22 15/08/2022
        /// Lấy danh sách lĩnh vực
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 4:22 15/08/2022
        /// Lấy danh sách lĩnh vực theo tên
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
