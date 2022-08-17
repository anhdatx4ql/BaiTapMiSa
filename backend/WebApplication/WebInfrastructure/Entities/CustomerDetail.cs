using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 16:38 12:08:2022
    /// bảng lưu thông tin chi tiêt khách hàng
    /// </summary>
    public class CustomerDetail
    {

        [Key]
        public Guid CustomerDetailID { set; get; }// Mã chi tiết khách hàng
        public string CustomerDetailName { set; get; }// Thông tin chi tiết
        public Guid CustomerId { set; get; }// Mã khách hàng
        public DateTime CreatedAt { set; get; }// Thời gian tạo
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật
        public string CreatedBy { set; get; }// Người tạo
        public string UpdatedBy { set; get; }// Người cập nhật

    }
}
