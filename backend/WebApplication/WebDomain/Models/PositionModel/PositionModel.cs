using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 5:26 15/08/2022
    /// function: chức danh view model
    /// </summary>
    public class PositionModel
    {
        public Guid PositionId { set; get; }// mã chức danh
        public string PositionName { set; get; }// Tên chức danh
    }
}
