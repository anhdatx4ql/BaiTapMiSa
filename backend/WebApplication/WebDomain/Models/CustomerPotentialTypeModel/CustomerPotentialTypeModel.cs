﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm Văn Đạt
    /// Created: 4:06 15/08/2022
    /// Form hiển thị tiềm năng khách hàng
    /// </summary>
    public class CustomerPotentialTypeModel
    {
        public Guid CustomerPotentialTypeId { set; get; }// mã loại tiềm năng khách hàng
        public Guid CustomerId { set; get; }// Mã khách hàng
        public Guid PotentialTypeId { set; get; }// Mã loại tiềm năng
        public string PotentialTypeName { set; get; }// Tên loại tiềm năng
    }
}
