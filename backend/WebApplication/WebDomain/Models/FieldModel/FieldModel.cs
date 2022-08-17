using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 4:26 15/08/2022
    /// function: lĩnh vưcj view model
    /// </summary>
    public class FieldModel
    {
        public Guid FieldId { set; get; }// Mã lĩnh vực
        public string FieldName { set; get; }//Tên lĩnh vực
    }
}
