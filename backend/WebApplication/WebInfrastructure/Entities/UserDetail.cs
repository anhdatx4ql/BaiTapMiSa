using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    public class UserDetail
    {
        [Key]
        public string UserDetailID { set; get; }// varchar(255), -- Guid
        public string UserDetailName { set; get; }// nvarchar(255), -- tên phòng ban
        public string UserId { set; get; }// nvarchar(255), -- tên phòng ban
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),
    }
}
