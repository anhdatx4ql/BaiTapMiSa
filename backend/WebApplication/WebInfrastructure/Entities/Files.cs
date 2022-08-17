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
    /// Created: 16:43 12:08:2022
    /// Bảng lưu ảnh
    /// </summary>
    public class Files
    {
        [Key]
        public Guid FileId { set; get; } // mã file ảnh
        public Guid EntityId { set; get; } // Mã chủ sở hữu
        public string FileName { set; get; } //tên file
        public string FileExtension { set; get; } // vđuôi file
        public string FileCapacity { set; get; } // dung lượng
        public DateTime CreatedAt { set; get; }// ngày tạo
        public DateTime UpdatedAt { set; get; }// ngày cập nhật
        public string CreatedBy { set; get; }// người tạo 
        public string UpdatedBy { set; get; }// người cập nhật

    }
}
