using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm Văn Đạt
    /// Created: 16:17 5/08/2022
    /// Các trường chi tiết khách hàng
    /// </summary>
    public class CustomerDetailModel
    {
        public Guid CustomerDetailID { set; get; }// Mã chi tiết khách hàng
        public string CustomerDetailName { set; get; }// Thông tin chi tiết
        public Guid CustomerId { set; get; }// Mã khách hàng
        public DateTime CreatedAt { set; get; }// Thời gian tạo
    }
}
