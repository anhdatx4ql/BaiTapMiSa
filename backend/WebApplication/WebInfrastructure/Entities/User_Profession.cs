using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng lưu thông tin nghề nghiệp của user
    public class User_Profession
    {
        [Key]
        public string User_ProfessionId { set; get; } // varchar(255) not null,
        public string UserId { set; get; } // varchar(255) not null,
        public string ProfessionId { set; get; } // varchar(255) not null,
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
