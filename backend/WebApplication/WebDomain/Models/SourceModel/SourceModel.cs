using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// - Model chứa thông tin hiển thị bảng nguồn gốc
    /// Created Time: 19:40 13/08/2022
    /// </summary>
    public class SourceModel
    {
        public Guid SourceId { set; get; } // mã nguồn gốc
        public string SourceName { set; get; } //Tên nguồn gốc...
    }
}
