using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng ngành nghề
    public class Professions
    {
        [Key]
        public string ProfessionId { set; get; }// varchar(255) not null,
        public string ProfessionName { set; get; }// nvarchar(255) not null, -- tên ngành nghề
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
