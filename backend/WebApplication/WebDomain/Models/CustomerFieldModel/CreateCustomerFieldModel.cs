using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm Văn Đạt
    /// Created: 3:27 13/08/2022
    /// Form thêm lĩnh vực khách hàng
    /// </summary>
    public class CreateCustomerFieldModel
    {
        public Guid CustomerId { set; get; }// Mã khách hàng
        public Guid FieldId { set; get; }// Mã lĩnh vực
    }
}
