using Common.Resources;
using Dapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;

namespace WebDomain
{
    public class FilesService : IFilesService
    {
        private readonly IDapperRepository _dapper;

        public FilesService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Function: Upload file
        /// </summary>
        /// <param name="objectFile">FileUpload</param>
        /// <param name="_customerId">Id khách hàng</param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> UploadFile(IFormFile objectFile, Guid _customerId)
        {
            try
            {

                if (objectFile.Length == 0)
                    return null;

                var currentDir = Directory.GetCurrentDirectory();

                if (!Directory.Exists(currentDir + "\\Resource\\Uploads\\"))
                    Directory.CreateDirectory(currentDir + "\\Resource\\Uploads\\");

                // start tao ten cho file upload
                string directoryPath = Path.Combine(currentDir, "\\Resource\\Uploads\\");
                string strDate = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                var fileExtension = Path.GetExtension(objectFile.FileName).Replace(".", "");
                var fileName = objectFile.FileName.Substring(objectFile.FileName.LastIndexOf("\\\\") + 1);
                // end tao ten cho file upload

                fileName = strDate + "-fileUpload" + "." + fileExtension;
                var filePath = currentDir + "\\Resource\\Uploads\\" + fileName;
                // start lưu file vào thư mục
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    objectFile.CopyTo(fileStream);
                    fileStream.Flush();
                }

                string[] strExtension = { "JPEG", "JPG", "PNG", "GIF", "TIFF" };
                var check = false;
                for(var i=0;i< strExtension.Length; i++)
                {
                    if(fileExtension.ToUpper() == strExtension[i])
                    {
                        check = true;
                        break;
                    }
                }

                if(check == true)
                {
                    // end lưu file vào thư mục: fileName, fileExtension, 
                    var file = new FileModel()
                    {
                        FileId = Guid.NewGuid(),
                        FileName = fileName,
                        Extension = fileExtension,
                        Path = filePath,
                        Size = objectFile.Length,
                        CustomerId = _customerId,
                        CreatedAt = DateTime.Now,

                    };

                    // lưu file vào db
                    if (file != null)
                    {
                        string sql = @"INSERT INTO files (FileId, FileName, Extension, Path, Size, EntityId, CreatedAt) VALUES (@FileId, @FileName, @Extension, @Path, @Size, @CustomerId, @CreatedAt)";

                        var result = await _dapper.CreateTAsync<FileModel>(sql, file);
                        return new ReponsitoryModel(file, CodeSuccess.Status201, MessageSuccess.CreatedSuccess);
                    }

                    return new ReponsitoryModel(null, CodeError.Code400, MessageError.NotValue);
                }

                return new ReponsitoryModel(null, CodeError.Code400, MessageError.FileMalformed);

            }
            catch(Exception ex)
            {
                return new ReponsitoryModel(ex.Message, CodeError.Code500, MessageError.ProcessError);
            }
        }

    }
}
