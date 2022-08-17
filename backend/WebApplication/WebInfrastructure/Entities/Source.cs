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
    /// Bảng nguồn gốc
    /// </summary>
    public class Source
    {
        [Key]
        public Guid SourceId { set; get; } // mã nguồn gốc
        public string SourceName { set; get; } //Tên nguồn gốc...
        public DateTime CreatedAt { set; get; } // Thời gian tạo,
        public DateTime UpdatedAt { set; get; } // Thời gian cập nhật,
        public string CreatedBy { set; get; } // Người tạo,
        public string UpdatedBy { set; get; } // Người cập nhật,

    }
}
