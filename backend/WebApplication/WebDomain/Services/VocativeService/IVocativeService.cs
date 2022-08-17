using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 10:55 13/08/2022
    /// Service xử lý bảng xưng hô
    /// </summary>
    public interface IVocativeService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Createa Time: 11:22 13/08/2022
        /// Lấy danh sách xưng hô
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Createa Time: 11:22 13/08/2022
        /// Lấy danh sách xưng hô theo tên
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
