using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng tiềm năng của user
    public class User_Potential
    {
        [Key]
        public string User_PotentialID { set; get; }// varchar(255) NOT NULL,
        public string UserId { set; get; }// varchar(255) not null,
        public string PotentialId { set; get; }// varchar(255) not null,
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
