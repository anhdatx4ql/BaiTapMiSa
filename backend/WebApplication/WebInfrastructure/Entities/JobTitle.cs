using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng chức danh
    public class JobTitle
    {
        [Key]
        public string JobTitleId { set; get; }// varchar(255) not null, -- id
        public string JobTitleName { set; get; }// nvarchar(255) not null, -- tên chức danh
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
