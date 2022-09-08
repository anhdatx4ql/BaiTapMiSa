using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created: 9:28 13/8/2022
    /// Model update customer: chứa các trường update của customer
    /// </summary>
    public class UpdateCustomerModel
    {
        // Xưng hô 1
        public Guid? VocativeId { set; get; }

        // họ và đệm 2
        public string LastName { set; get; }
        // tên
        public string FirstName { set; get; }

        // họ và tên 3
        public string FullName { set; get; }

        // Phòng ban 4
        public Guid? DepartmentId { set; get; }

        // Chức danh 5
        public Guid? PositionId { set; get; }

        // Điện thoại di động cá nhân 6
        public string CustomerPhoneNumber { set; get; }

        // Điện thoại cơ quan 7
        public string CompanyPhoneNumber { set; get; }

        // Loại tiềm năng 8
        //public Guid CustomerPotentialTypeId { set; get; }

        // Nguồn gốc 9
        public Guid? SourceId { set; get; }

        // Không gọi điện  10
        public bool IsActivePhoneNumber { set; get; }

        // Không gửi email 11
        public bool IsActiveEmail { set; get; } //-- cho phép gửi email

        // email cá nhân 12
        public string CustomerEmail { set; get; }

        // zalo 13
        public string Zalo { set; get; }

        // email cá cơ quan 14
        public string CompanyEmail { set; get; }

        // tổ chức 15
        public string Organization { set; get; }

        //mã số thuế 16
        public string TaxCode { set; get; }
        
        // ngày sinh 17
        public string BirthDay { set; get; }

        // giới tính 18
        public int Gender { set; get; }

        // facebook 19
        public string Facebook { set; get; }


    }
}
