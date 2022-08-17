using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// CreatedAt: 9:27 13/08/2022
    /// form thêm khách hàng
    /// </summary>
    public class CreateCustomerModel
    {
        public Guid CustomerId { set; get; } // Id customer + 
        //[Required(ErrorMessage ="Mã Tiềm năng không được bỏ trống")]
        //[StringLength(50)]
        public string PotentialCode { set; get; } // Mã tiềm năng + 
        public string LastName { set; get; } // Họ và đệm + 
        [Required(ErrorMessage = "Tên không được bỏ trống")]
        [StringLength(50)]
        public string FirstName { set; get; } // Tên + 
        public string FullName { set; get; } // họ và tên +
        public string CustomerPhoneNumber { set; get; } // số điện thoại cá nhân + 
        public string CompanyPhoneNumber { set; get; }// số điện thoại công ty +

        [EmailAddress(ErrorMessage ="Không đúng định dạng Email")]
        public string CustomerEmail { set; get; } // email cá nhân + 

        [EmailAddress(ErrorMessage = "Không đúng định dạng Email")]
        public string CompanyEmail { set; get; } // email công ty + 
        public string Zalo { set; get; } // zalo + 
        public string TaxCode { set; get; } //mã số thuế + 
        public string Organization { set; get; } //tổ chức +
        public string CustomerDescription { set; get; } // mô tả thông tin+
        public string Address { set; get; } // địa chỉ + 
        public string Country { set; get; } //-- quốc gia + 
        public string Province { set; get; } //-- thanhf phoos + 
        public string District { set; get; } //-- Quận/Huyện

        public string Wards { set; get; }// Phường xã
        public string HomeNumber { set; get; } //-- số nhà + 
        public string RegionCode { set; get; } //-- mã vùng +
        public string BankAccount { set; get; } //-- tài khoản ngân hàng + 
        public string BankName { set; get; } //-- mo tai ngan hangf + 
        public DateTime CreatedTimeBankAccount { set; get; } //-- ngày tạo tài khoản + 
        public Guid VocativeId { set; get; } //-- xưng hô + 
        public Guid DepartmentId { set; get; } //-- một người - 1 phòng ban +
        public Guid SourceId { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng + 
        public Guid PositionId { set; get; } //-- 1 người - 1 chức danh +
        public Guid TurnoverId { set; get; } //-- doanh thu của tổ chức + 
        public Guid OrganizationTypeId { set; get; } //-- Loai hinhf + 
        public DateTime CreatedAt { set; get; } // ngày tạo + 
        public DateTime updatedAt { set; get; } // ngày tạo + 
        public string CreatedBy { set; get; } // Ngươi tạo +
        public string UpdatedBy { set; get; }// Người cập nhật + 
        public bool IsDelete { set; get; } // kiem tra xem đã  + 
    }
}
