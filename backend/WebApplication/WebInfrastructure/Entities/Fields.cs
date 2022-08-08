using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    // bảng lĩnh vực
    public class Fields
    {
        [Key]
        public string FieldId { set; get; }// varchar(255) not NULL,
        public string FieldName { set; get; }//varchar(255) int not null,
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
