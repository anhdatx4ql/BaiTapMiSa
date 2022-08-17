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
    /// Created: 16:41 12:08:2022
    /// Bảng lưu thông tin tiềm năng của khách hàng
    /// </summary>
    public class CustomerPotentialType
    {
        [Key]
        public Guid CustomerPotentialTypeId { set; get; }// mã loại tiềm năng khách hàng
        public Guid CustomerId { set; get; }// Mã khách hàng
        public Guid PotentialTypeId { set; get; }// Mã loại tiềm năng
        public DateTime CreatedAt { set; get; }// Ngày tạo
        public DateTime UpdatedAt { set; get; }// Ngày cập nhật
        public string CreatedBy { set; get; }// Người tạo
        public string UpdatedBy { set; get; }// Người cập nhật

    }
}
