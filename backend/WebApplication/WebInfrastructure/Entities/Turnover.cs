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
    /// Created: 16:49 12:08:2022
    /// Bảng doanh thu
    /// </summary>
    public class Turnover
    {
        [Key]
        public Guid TurnoverId { set; get; }// mã doanh thu
        public string TurnoverName { set; get; }// giá trị doanh thu
        public DateTime CreatedAt { set; get; }// Thời gian tạo
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật
        public string CreatedBy { set; get; }// người tạo
        public string UpdatedBy { set; get; }// người cập nhật

    }
}
