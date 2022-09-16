using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    public interface IFilesService
    {
        
        /**
         * Auhor: Phạm Văn Đạt
         * function: upload file
         */
        Task<ReponsitoryModel> UploadFile(IFormFile objectFile, Guid _userId);
    }
}
