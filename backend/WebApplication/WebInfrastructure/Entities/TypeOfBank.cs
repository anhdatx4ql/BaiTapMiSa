using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{
    public class TypeOfBank
    {
        [Key]
        public string TypeOfBanklId { set; get; }// varchar(255) not NULL,
        public string TypeOfBankName { set; get; }//varchar(255) int not null,
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),
    }
}
