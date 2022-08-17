﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 2:56 15/08/2022
    /// Service xử lý tiềm năng khách hàng
    /// </summary>
    public interface ICustomerPotentialTypeService
    {
        /// <summary>
        /// lấy danh sách lĩnh vực
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAll();


        /// <summary>
        /// danh sách lĩnh vực khách hàng theo tên
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> GetByName(string search);

        /// <summary>
        /// Tạo mới lĩnh vực khách hàng
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ReponsitoryModel> Create(CreateCustomerPotentialTypeModel[] models);
    }
}
