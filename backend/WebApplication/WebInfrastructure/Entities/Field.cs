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
    /// Bảng lĩnh vực
    /// </summary>
    public class Field
    {
        [Key]
        public Guid FieldId { set; get; }// Mã lĩnh vực
        public string FieldName { set; get; }//Tên lĩnh vực
        public DateTime CreatedAt { set; get; }// Ngày tạo,
        public DateTime UpdatedAt { set; get; }// ngày cập nhật,
        public string CreatedBy { set; get; }// Người tạo,
        public string UpdatedBy { set; get; }// Người cập nhật,

    }
}
