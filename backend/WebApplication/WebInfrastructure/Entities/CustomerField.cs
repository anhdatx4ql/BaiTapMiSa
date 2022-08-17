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
    /// Bảng thông tin lĩnh vực của khách hàng
    /// </summary>
    public class CustomerField
    {
        [Key]
        public Guid CustomerFieldId { set; get; }// Mã lĩnh vực khách hàng
        public Guid CustomerId { set; get; }// Mã khách hàng
        public Guid FieldId { set; get; }// Mã lĩnh vực
        public DateTime CreatedAt { set; get; }// Thời gian tạo
        public DateTime UpdatedAt { set; get; }// Thời gian cập nhật,
        public string CreatedBy { set; get; }// người tạo,
        public string UpdatedBy { set; get; }// người cập nhật,

    }
}
