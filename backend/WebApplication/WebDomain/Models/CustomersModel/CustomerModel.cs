using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// bảng lấy thông tin khách hàng
    /// Author: Phạm Văn Đạt
    /// </summary>
    public class CustomerModel
    {
        public Guid? CustomerId { set; get; } // Id customer
        public string PotentialCode { set; get; } // Mã tiềm năng
        public string FullName { set; get; } // họ và tên
        public string CustomerPhoneNumber { set; get; } // số điện thoại cá nhân
        public string CompanyPhoneNumber { set; get; }// số điện thoại công ty
        public string CustomerEmail { set; get; } // email cá nhân
        public string CompanyEmail { set; get; } // email công ty
        public string Zalo { set; get; } // zalo
        public string TaxCode { set; get; } //mã số thuế
        public string Organization { set; get; } //tổ chức
        public string Address { set; get; } // địa chỉ
        public Guid VocativeId { set; get; } //-- xưng hô
        public string VocativeName { set; get; } //-- xưng hô
        public Guid DepartmentId { set; get; } //-- một người - 1 phòng ban
        public string DepartmentName { set; get; } //-- một người - 1 phòng ban
        public Guid SourceId { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng
        public string SourceName  { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng
        public Guid PositionId { set; get; } //-- 1 người - 1 chức danh
        public string PositionName { set; get; } //-- 1 người - 1 chức danh
        public Guid TurnoverId { set; get; } //-- doanh thu của tổ chức
        public string TurnoverName { set; get; } //-- doanh thu của tổ chức
        public Guid OrganizationTypeId { set; get; } //-- Loai hinhf
        public string OrganizationTypeName { set; get; } //-- Loai hinhf
        public bool IsDelete { set; get; }
    }
}
