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
    /// Created: 16:46 12:08:2022
    /// Bảng chức danh
    /// </summary>
    public class Positions
    {
        [Key]
        public Guid PositionId { set; get; }// mã chức danh
        public string PositionName { set; get; }// Tên chức danh
        public DateTime CreatedAt { set; get; }// Thời gian tạo
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật
        public string CreatedBy { set; get; }// người tạo 
        public string UpdatedBy { set; get; }// Người cập nhật

    }
}
