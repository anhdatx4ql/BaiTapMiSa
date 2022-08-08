using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng phòng ban
    public class Department
    {
        [Key]
        public string DepartmentID { set; get; }// varchar(255), -- Guid
        public string DepartmentName { set; get; }// nvarchar(255), -- tên phòng ban
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),
    }
}
