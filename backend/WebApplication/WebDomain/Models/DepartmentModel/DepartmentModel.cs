using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{

    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 11:32 13/08/2022 12:08:2022
    /// bảng lưu Phòng ban view model
    /// </summary>
    public class DepartmentModel
    {
        public Guid DepartmentId { set; get; }// mã phòng ban
        public string DepartmentName { set; get; }// Tên phòng ban
    }
}
