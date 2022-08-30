using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ExcelModel
    {

        // / <summary>
        /// Xưng hô
        // / </summary>
         public string VocativeName { set; get; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { set; get; }

        /// <summary>
        /// Email cá nhân
        /// </summary>
        public string CustomerEmail { set; get; }

        /// <summary>
        /// Email công ty
        /// </summary>
        public string CompanyEmail { set; get; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public string PositionName { set; get; }

        /// <summary>
        /// Điện thoại cá nhân
        /// </summary>
        public string CustomerPhoneNumber { set; get; }

        /// <summary>
        /// Điện thoại cơ quan
        /// </summary>
        public string CompanyPhoneNumber { set; get; }

        /// <summary>
        /// Tổ chức
        /// </summary>
        public string Organization { set; get; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { set; get; }

        /// <summary>
        /// Doanh thu
        /// </summary>
        public string TurnoverName { set; get; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { set; get; }
    }
}
