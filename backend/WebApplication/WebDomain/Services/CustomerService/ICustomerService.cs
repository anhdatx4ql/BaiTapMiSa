using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Service xử lý nghiệp vụ customer (khách hàng)
    /// Author: Phạm Văn Đạt 
    /// 18:20 10/08/2022
    /// </summary>
   public interface ICustomerService
    {
        /// <summary>
        /// Xuất file excel
        /// </summary>
        /// <param name="ListCustomerId">mảng ID kháchhangf</param>
        /// <returns></returns>
        Task<byte[]> ExportExcel(List<Guid> ListCustomerId = null);


        /// <summary>
        /// Phân trang + tìm kiếm
        /// </summary>
        /// <param name="keyword">Giá trị tìm kiếm</param>
        /// <param name="currentPageNumber">Trang hiện tại</param>
        /// <param name="pageSize">Số lượng bản ghi/Trang</param>
        /// <returns></returns>
        Task<ReponsitoryModel> PagingCustomer(string keyword = null, int currentPageNumber=1, int pageSize = 10);



        /// <summary>
        /// Lấy thông tin khách hàng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<ReponsitoryModel> GetAllCustomer();

        /// <summary>
        /// Tạo mới khách hàng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> CreateCustomer(CreateCustomerModel model);

        /// <summary>
        /// Sửa thông tin khách hàng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> UpdateCustomer(UpdateCustomerModel model,string id);
        
        /// <summary>
        /// Xóa thông tin khách hàng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> DeleteCustomer(List<Guid> ListString);

        /// <summary>
        /// Tìm kiếm khách hàng theo họ và tên
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> GetCustomerByFullName(string search);
        
        /// <summary>
        /// Lẫy mã tiềm năng lớn nhất
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> GetCustomerCodeMax();

        /// <summary>
        /// Check trùng mã tiềm năng
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> CheckExistColumn(FormCheckExists model);


        /// <summary>
        /// Update nhiều
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        Task<ReponsitoryModel> UpdateCustomerMul(UpdateCustomerMul model);

    }
}
