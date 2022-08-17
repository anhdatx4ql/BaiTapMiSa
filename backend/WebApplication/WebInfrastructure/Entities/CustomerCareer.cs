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
    /// bảng lưu thông tin nghề nghiệp của khách hàng
    /// </summary>
    public class CustomerCareer
    {
        [Key]
        public Guid CustomerCareerId { set; get; } // mã thông tin nghề nghiệp của khách hàng
        public Guid CustomerId { set; get; } // mã khách hàng
        public Guid CareerID { set; get; } // Mã nghề nghiệp,
        public DateTime CreatedAt { set; get; }//Thời gian tạo,
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật,
        public string CreatedBy { set; get; }// Người tạo
        public string UpdatedBy { set; get; }// người cập nhật

    }
}
