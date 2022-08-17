using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time: 5:53 15/08/2022
    /// function: Service xử lý bảng loại tiềm năng
    /// </summary>
    public interface IPotentialTypeService
    {
        /// <summary>
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
