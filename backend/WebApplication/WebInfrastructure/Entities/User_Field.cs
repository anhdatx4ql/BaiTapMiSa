using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng lưu thông tin lĩnh vực của user
    public class User_Field
    {
        [Key]
        public string User_FieldId { set; get; }// varchar(255) not null,
        public string UserId { set; get; }// varchar(255) not null,
        public string FieldId { set; get; }// varchar(255) not null,
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
