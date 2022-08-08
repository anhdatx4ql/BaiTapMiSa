using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng lưu file
    public class Files
    {
        [Key]
        public string FileId { set; get; } // varchar(255) not null,
        public string FileName { set; get; } //varchar(255) not null,
        public string FileExtension { set; get; } // varchar(255) not null,
        public string FileCapacity { set; get; } // long not null,
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
