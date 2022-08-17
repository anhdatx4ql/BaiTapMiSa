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
    /// Created: 16:53 12:08:2022
    /// bảng lưu Xưng hô
    /// </summary>
    public class Vocative
    {

        [Key]
        public Guid VocativeId { set; get; } // -- Mã xưng hô
        public string VocativeName { set; get; } // Tên xưng hô
        public DateTime CreatedAt { set; get; } //  Thời gian tạo
        public DateTime UpdatedAt { set; get; } //  Thời gian cập nhật
        public string CreatedBy { set; get; } //  Người tạo
        public string UpdatedBy { set; get; } // Người cập nhật

    }
}
