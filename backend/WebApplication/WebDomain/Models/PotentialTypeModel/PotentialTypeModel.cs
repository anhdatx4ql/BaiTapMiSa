using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 5:51 15/08/2022
    /// function: loại tiềm năng view model
    /// </summary>
    public class PotentialTypeModel
    {
        public Guid PotentialTypeId { set; get; }// mã loại tiềm năng
        public string PotentialTypeName { set; get; }//tên loại tiềm năng
    }
}
