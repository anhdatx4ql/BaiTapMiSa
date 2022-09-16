using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    public class FileModel
    {
        //  file id
        public Guid FileId { set; get; }

        // tên file
        public string FileName { get; set; }

        // đuôi file
        public string Extension { get; set; }

        // đường dẫn
        public string Path { get; set; }

        // dung lượng
        public long Size { get; set; }

        // id khách hàng
        public Guid CustomerId { set; get; }

        // ngày tạo + 
        public DateTime CreatedAt { set; get; }

        // Ngươi tạo +
        public string CreatedBy { set; get; }
    }
}
