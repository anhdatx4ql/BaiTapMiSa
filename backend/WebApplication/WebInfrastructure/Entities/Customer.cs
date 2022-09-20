using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure
{
    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 16:38 08:08:2022
    /// bảng khách hàng
    /// </summary>
    public class Customer
    {
        public Guid CustomerId { set; get; } // Id customer
        public string PotentialCode { set; get; } // Mã tiềm năng
        public string LastName { set; get; } // Họ và đệm
        public string FirstName { set; get; } // Tên
        public string FullName { set; get; } // họ và tên
        public string CustomerPhoneNumber { set; get; } // số điện thoại cá nhân
        public string CompanyPhoneNumber { set; get; }// số điện thoại công ty
        [Column(TypeName = "Email")]
        public string CustomerEmail { set; get; } // email cá nhân
        [Column(TypeName = "Email")]
        public string CompanyEmail { set; get; } // email công ty
        public string Zalo { set; get; } // zalo
        public string TaxCode { set; get; } //mã số thuế
        public string Organization { set; get; } //tổ chức
        public Nullable<int> Gender { set; get; } // giới tính
        public DateTime BirthDay { set; get; } // ngày sinh
        public string CustomerDescription { set; get; } // mô tả thông tin
        public string Address { set; get; } // địa chỉ
        public string Country { set; get; } //-- quốc gia
        public string Province { set; get; } //-- thanhf phoos
        public string District { set; get; } //-- Quận/Huyện                                       
        public string Wards { set; get; }// Phường xã
        public string HomeNumber { set; get; } //-- số nhà
        public string RegionCode { set; get; } //-- mã vùng
        public string BankAccount { set; get; } //-- tài khoản ngân hàng
        public string BankName { set; get; } //-- mo tai ngan hangf
        public DateTime CreatedTimeBankAccount { set; get; } //-- ngày tạo tài khoản
        public string Facebook { set; get; } //-- facebook
        public bool IsActivePhoneNumber { set; get; } //-- cho phép gọi điện
        public bool IsActiveEmail { set; get; } //-- cho phép gửi email
        public Guid? VocativeId { set; get; } //-- xưng hô
        public Guid? DepartmentId   { set; get; } //-- một người - 1 phòng ban
        public Guid? SourceId { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng
        public Guid? PositionId { set; get; } //-- 1 người - 1 chức danh
        public Guid? TurnoverId { set; get; } //-- doanh thu của tổ chức
        public Guid? OrganizationTypeId { set; get; } //-- Loai hinhf
        public DateTime CreatedAt { set; get; } // ngày tạo
        public DateTime UpdatedAt { set; get; } // ngày cập nhật
        public string CreateaBy { set; get; } // người tạo
        public string UpdatedBy { set; get; } // người cập nhật
        public bool IsDelete { set; get; } // kiểm tra xem dòng dữ liệu đã xóa chưa
    }

}
