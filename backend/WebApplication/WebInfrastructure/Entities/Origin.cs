using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng nguồn gốc
    public class Origin
    {
        [Key]
        public string OriginId { set; get; } //varchar(255) not null, -- id(Guid)
        public string OriginName { set; get; } //nvarchar(255) not null, -- Nơi nguồn gốc xuất hiện tiềm năng: kênh bán hàng, kênh online, facebook,...
        public DateTime CreatedAt { set; get; } // datetime,
        public DateTime UpdatedAt { set; get; } // datetime,
        public string CreatedBy { set; get; } // varchar(255),
        public string UpdatedBy { set; get; } // varchar(255),

    }
}
