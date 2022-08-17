using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 16:46 12:08:2022
    /// Bảng Loại tiềm năng
    /// </summary>
    public class PotentialType
    {
        [Key]
        public Guid PotentialTypeId { set; get; }// mã loại tiềm năng
        public string PotentialTypeName { set; get; }//tên loại tiềm năng
        public DateTime CreatedAt { set; get; }// datetime,
        public DateTime UpdatedAt { set; get; }// datetime,
        public string CreatedBy { set; get; }// varchar(255),
        public string UpdatedBy { set; get; }// varchar(255),

    }
}
