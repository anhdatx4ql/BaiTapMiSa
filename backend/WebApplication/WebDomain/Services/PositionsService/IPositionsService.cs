using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 5:27 15/08/2022
    /// function: Service xử lý bảng chức danh
    /// </summary>
    public interface IPositionsService
    {
        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Author: Phạm Văn Đạt
        /// Created Time: 5:27 15/08/2022
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 5:27 15/08/2022
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllByName(string name);
    }
}
