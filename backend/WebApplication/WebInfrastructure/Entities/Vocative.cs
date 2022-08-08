using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    public class Vocative
    {
        [Key]
        public string VocativeId { set; get; } // -- Guid id xưng hô
        public string VocativeName { set; get; } //  nvarchar(255) not null, -- tên xưng hô
        public DateTime CreatedAt { set; get; } //  datetime, -- ngày tạo
        public DateTime UpdatedAt { set; get; } //  datetime, -- ngày cập nhật
        public string CreatedBy { set; get; } //  varchar(255), -- người tạo
        public string UpdatedBy { set; get; } // varchar(255), -- người cập nhật

    }
}
