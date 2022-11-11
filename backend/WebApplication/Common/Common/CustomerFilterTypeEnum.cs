using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    
    /// <summary>
    /// chứa 3 form dùng để lọc dữ liệu
    /// </summary>

    public enum CustomerFilterTypeEnum
    {
        // Là
         Exactly= 0,

        // CHứa
         Contain= 1,

        // không trống
         NotEmpty= 2,

         /// <summary>
         /// Trống
         /// </summary>
         Empty=3
    }
}
