using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm Văn Đạt
    /// Created: 4:06 15/08/2022
    /// Form thêm tiềm năng khách hàng
    /// </summary>
    public class CreateCustomerPotentialTypeModel
    {
        public Guid CustomerId { set; get; }// Mã khách hàng
        public string PotentialTypeId { set; get; }// Mã loại tiềm năng
    }
}
