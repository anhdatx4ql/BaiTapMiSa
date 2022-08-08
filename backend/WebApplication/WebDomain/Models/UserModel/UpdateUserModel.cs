using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain.Models.UserModel
{
    public class UpdateUserModel
    {
        public string FirstName { set; get; } // họ và đệm
        public string LastName { set; get; } // tên
        public string FullName { set; get; } // họ và tên
        public string UserNummberPhone { set; get; } // số điện thoại cá nhân
        public string CompanyNumberPhone { set; get; }// số điện thoại công ty
        public string UserEmail { set; get; } // email cá nhân
        public string CompanyEmail { set; get; } // email công ty
        public string Zalo { set; get; } // 
        public string TaxCode { set; get; } //mã số thuế
        public string Organize { set; get; } //tổ chức
        public bool Gender { set; get; } // giới tính
        public DateTime BirthDay { set; get; }
        public string Facebook { set; get; } //-- facebook
        public bool IsUserPhoneActive { set; get; } //-- cho phép gọi điện
        public bool IsUserEmailActive { set; get; } //-- cho phép gửi email
        public string VocativeId { set; get; } //-- xưng hô
        public string DepartmentID { set; get; } //-- một người - 1 phòng ban
        public string OriginId { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng
        public string JobTitleId { set; get; } //-- 1 người - 1 chức danh
        public string RevenueID { set; get; } //-- doanh thu của tổ chức
        public string CreateaBy { set; get; }
        public string UpdatedBy { set; get; }
    }
}
