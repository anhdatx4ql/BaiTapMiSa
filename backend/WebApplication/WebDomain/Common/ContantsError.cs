using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    public class ContantsError
    {
        /// <summary>
        /// Class lưu message lỗi
        /// Author: Phạm Văn Đạt
        /// DateTime: 9:22 10/08/2022
        /// </summary>
        public class MessageError
        {
            public const string DuplicateName = "Tên đã bị trùng. Vui lòng đổi tên khác!";
            public const string DuplicateEmail = "Email đã đăng ký. Vui lòng đổi tên khác!";
            public const string DuplicatePhone = "Số điện thoại đã đăng ký. Vui lòng đổi số khác!";
            public const string DuplicateTaxCode = "Mã số thuế đã bị trùng. Vui lòng đổi mã khác!";
            public const string DuplicateCode = "Mã đã bị trùng. Vui lòng đổi mã khác!";
            public const string DuplicateBankAccount = "Tài khoản này đã có người sử dụng. Vui lòng đổi tài khoản khác!";
            public const string NotExists = "không được bỏ trống!";
            public const string NotFound = "Bản ghi đã chọn không tồn tại!";
            public const string DuplicateValue = "Bản ghi đã tồn tại. Không thể thêm!";
            public const string NotValue = "Không có dữ liệu";
            public const string ProcessError = "Có lỗi trong quá trình xử lý.";
            public const string CreatedFail = "Thêm mới thất bại.";
            public const string DeletedFail = "Xóa bản ghi thất bại.";
            public const string UpdatedFail = "Cập nhật thông tin thất bại.";
            public const string GenderExists = "Giới tính không tồn tại.";
        }

        /// <summary>
        /// Class lưu code lỗi
        /// Author: Phạm Văn Đạt
        /// DateTime: 9:22 10/08/2022
        /// </summary>
        public class CodeError
        {
            public const string DuplicateName = "400";
            public const string DuplicateCode = "400";
            public const string NotFound = "400";
            public const string NotValue = "400";
            public const string ProcessError = "400";
            public const string CreateFailed = "400";
            public const string UpdateFailed = "400";
            public const string NotExists = "400";
            public const string DuplicateEmail = "400";
            public const string DuplicatePhone = "400";
            public const string DuplicateTaxCode = "400";
            public const string DuplicateBankAccount = "400";
            public const string DeletedFail = "400";
            public const string DuplicateValue = "400";
            public const string GenderExists = "400";
        }
    }
}
