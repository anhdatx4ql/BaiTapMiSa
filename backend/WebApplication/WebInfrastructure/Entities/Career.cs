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
    /// Bảng ngành nghề
    /// </summary>
    public class Career
    {
        [Key]
        public Guid CareerId { set; get; }// mã ngành nghề
        public string CareerName { set; get; }// tên ngành nghề
        public DateTime CreatedAt { set; get; }// Thời gian tạo
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật
        public string CreatedBy { set; get; }// Người tạo
        public string UpdatedBy { set; get; }// Người cập nhật

    }
}
