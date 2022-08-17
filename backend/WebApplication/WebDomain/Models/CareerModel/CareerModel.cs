using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm Văn Đạt
    /// Created: 9:29 13/08/2022
    /// Form thêm ngành nghề khách hàng
    /// </summary>
    public class CareerModel
    {
        public Guid CareerId { set; get; }// mã ngành nghề
        public string CareerName { set; get; }// tên ngành nghề
    }
}
