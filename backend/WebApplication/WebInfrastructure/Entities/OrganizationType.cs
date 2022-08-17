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
    /// Bảng loại hình tổ chức
    /// </summary>
    public class OrganizationType
    {
        [Key]
        public Guid OrganizationTypeId { set; get; }// mã loại hình
        public string OrganizationTypeName { set; get; }// tên loại hình
        public DateTime CreatedAt { set; get; }// Thời gian tạo
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật
        public string CreatedBy { set; get; }// người tạo,
        public string UpdatedBy { set; get; }// người cập nhật,

    }
}
