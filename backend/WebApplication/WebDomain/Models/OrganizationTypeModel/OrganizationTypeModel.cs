using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 4:34 15/08/2022
    /// function: loại hình tổ chức view model
    /// </summary>
    public class OrganizationTypeModel
    {
        public Guid OrganizationTypeId { set; get; }// mã loại hình
        public string OrganizationTypeName { set; get; }// tên loại hình
    }
}
