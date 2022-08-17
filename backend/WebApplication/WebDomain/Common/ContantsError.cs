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
        }

        /// <summary>
        /// Class lưu code lỗi
        /// Author: Phạm Văn Đạt
        /// DateTime: 9:22 10/08/2022
        /// </summary>
        public class CodeError
        {
            public const string DuplicateName = "E001";
            public const string DuplicateCode = "E002";
            public const string NotFound = "E003";
            public const string NotValue = "E004";
            public const string ProcessError = "E005";
            public const string CreateFailed = "E006";
            public const string UpdateFailed = "E007";
            public const string NotExists = "E008";
            public const string DuplicateEmail = "E009";
            public const string DuplicatePhone = "E010";
            public const string DuplicateTaxCode = "E011";
            public const string DuplicateBankAccount = "E012";
            public const string DeletedFail = "E013";
            public const string DuplicateValue = "E014";
        }
    }
}
