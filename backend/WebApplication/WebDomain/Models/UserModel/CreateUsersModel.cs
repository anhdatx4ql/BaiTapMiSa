using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain.Models
{
    public class CreateUsersModel
    {
        public string UserId { set; get; } // mã tiềm năng +
        public string FirstName { set; get; } // họ và đệm +
        public string LastName { set; get; } // tên +
        public string FullName { set; get; } // họ và tên +
        public string UserNumberPhone { set; get; } // số điện thoại cá nhân +
        public string CompanyNumberPhone { set; get; }// số điện thoại công ty +
        public string UserEmail { set; get; } // email cá nhân +
        public string CompanyEmail { set; get; } // email công ty +
        public string Zalo { set; get; } //  +
        public string TaxCode { set; get; } //mã số thuế +
        public string Organize { set; get; } //tổ chức +
        public string UserDescription { set; get; } // mô tả thông tin +
        public string Address { set; get; } // địa chỉ +
        public string Country { set; get; } //-- quốc gia +
        public string City { set; get; } //-- thanhf phoos +
        public string District { set; get; } //-- Huyện +
        public string Commune { set; get; } //-- Xã +
        public string ApartmentNumber { set; get; } //-- số nhà +
        public string AreaCode { set; get; } //-- mã vùng +
        public string BankAccount { set; get; } //-- tài khoản ngân hàng +
        public string OpenAtBank { set; get; } //-- mo tai ngan hangf +
        public DateTime DateBank { set; get; } //-- ngày tạo tài khoản +
        public string VocativeId { set; get; } //-- xưng hô +
        public string DepartmentID { set; get; } //-- một người - 1 phòng ban +
        public string OriginId { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng +
        public string JobTitleId { set; get; } //-- 1 người - 1 chức danh +
        public string RevenueID { set; get; } //-- doanh thu của tổ chức +
        public string TypeOfBankId { set; get; } //-- Loai hinhf
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
        public string CreateaBy { set; get; }
        public string UpdatedBy { set; get; }

    }
}
