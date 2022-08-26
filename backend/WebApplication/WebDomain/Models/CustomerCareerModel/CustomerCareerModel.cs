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
    /// Các trường ngành nghề khách hàng
    /// </summary>
    public class CustomerCareerModel
    {
        public Guid CustomerCareerId { set; get; } // mã thông tin nghề nghiệp của khách hàng
        public Guid CustomerId { set; get; } // mã khách hàng
        public Guid CareerId { set; get; } // Mã nghề nghiệp,
        public string CareerName { set; get; } // Teen nghề nghiệp,
    }
}
