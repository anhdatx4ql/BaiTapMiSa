using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain;

namespace WebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _service;


        public FilesController(IFilesService service)
        {
            _service = service;
        }


        
        [HttpPost]
        public async Task<ReponsitoryModel> UploadFile(IFormFile files,Guid customerId)
        {
            return await _service.UploadFile(files, customerId);
        }


    }
}
