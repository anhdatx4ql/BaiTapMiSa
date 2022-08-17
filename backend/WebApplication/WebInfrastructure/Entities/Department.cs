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
    /// Bảng phòng ban
    /// </summary>
    public class Department
    {

        [Key]
        public Guid DepartmentId { set; get; }// mã phòng ban
        public string DepartmentName { set; get; }// Tên phòng ban
        public DateTime CreatedAt { set; get; }// thời gian tạo
        public DateTime UpdatedAt { set; get; }// thời gian cập nhật
        public string CreatedBy { set; get; }// Người tạo
        public string UpdatedBy { set; get; }// Người cập nhật

    }
}
