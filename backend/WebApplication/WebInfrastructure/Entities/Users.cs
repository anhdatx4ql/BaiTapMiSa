﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Entities
{

    // tạo bản ghi dư thừa
    public class Users
    {
        [Key]
        public string UserId { set; get; } // Id
        public string FirstName { set; get; } // họ và đệm
        public string LastName { set; get; } // tên
        public string FullName { set; get; } // họ và tên
        public string UserNumberPhone { set; get; } // số điện thoại cá nhân
        public string CompanyNumberPhone { set; get; }// số điện thoại công ty
        public string UserEmail { set; get; } // email cá nhân
        public string CompanyEmail { set; get; } // email công ty
        public string Zalo { set; get; } // 
        public string TaxCode { set; get; } //mã số thuế
        public string Organize { set; get; } //tổ chức
        public bool Gender { set; get; } // giới tính
        public DateTime BirthDay { set; get; }
        public string UserDescription { set; get; } // mô tả thông tin
        public string Address { set; get; } // địa chỉ
        public string Country { set; get; } //-- quốc gia
        public string City { set; get; } //-- thanhf phoos
        public string District { set; get; } //-- Huyện
        public string Commune { set; get; } //-- Xã
        public string ApartmentNumber { set; get; } //-- số nhà
        public string AreaCode { set; get; } //-- mã vùng
        public string BankAccount { set; get; } //-- tài khoản ngân hàng
        public string OpenAtBank { set; get; } //-- mo tai ngan hangf
        public DateTime DateBank { set; get; } //-- ngày tạo tài khoản
        public string Facebook { set; get; } //-- facebook
        public bool IsUserPhoneActive { set; get; } //-- cho phép gọi điện
        public bool IsUserEmailActive { set; get; } //-- cho phép gửi email
        public string VocativeId { set; get; } //-- xưng hô
        //public string VocativeName { set; get; } //-- xưng hô name
        public string DepartmentID { set; get; } //-- một người - 1 phòng ban
        //public string DepartmentName { set; get; } //-- một người - 1 phòng ban name
        public string OriginId { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng
        //public string Originname { set; get; } //-- 1 người - 1 nguồn gốc tiềm năng name
        public string JobTitleId { set; get; } //-- 1 người - 1 chức danh
        //public string JobTitleName { set; get; } //-- 1 người - 1 chức danh name
        public string RevenueID { set; get; } //-- doanh thu của tổ chức
        //public string RevenueName { set; get; } //-- doanh thu của tổ chức  name
        public string TypeOfBankId { set; get; } //-- Loai hinhf
        //public string TypeOfBankName { set; get; } //-- Loai hinhf
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
        public string CreateaBy { set; get; }
        public string UpdatedBy { set; get; }
        public bool IsDelete { set; get; }
    }
}
