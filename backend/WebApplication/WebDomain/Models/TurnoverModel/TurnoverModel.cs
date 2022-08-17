using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// - Model chứa thông tin hiển thị bảng doanh thu
    /// Created Time: 19:40 13/08/2022
    /// </summary>
    public class TurnoverModel
    {
        public Guid TurnoverId { set; get; }// mã doanh thu
        public string TurnoverName { set; get; }// giá trị doanh thus
    }
}
