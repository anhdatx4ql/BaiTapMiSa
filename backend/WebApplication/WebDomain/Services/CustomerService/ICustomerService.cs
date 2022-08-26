using System;
using System.Collections.Generic;
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



    }
}
