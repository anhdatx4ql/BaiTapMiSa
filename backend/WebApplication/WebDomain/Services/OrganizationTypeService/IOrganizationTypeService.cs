using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 4:35 15/08/2022
    /// function: Service xử lý bảng loại hình tổ chức
    /// </summary>
    public interface IOrganizationTypeService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 4:22 15/08/2022
        /// Lấy danh sách loại hình tổ chức
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 4:22 15/08/2022
        /// Lấy danh sách loại hình tổ chức theo tên
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
