using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Interfaces;
using WebDomain.Models;
using WebInfrastructure.Entities;
using WebInfrastructure.Repositories;

namespace WebDomain.Services
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IDapperRepository _dapper;
        public JobTitleService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<ReponsitoryModel> getAllJobTitle()
        {
            try
            {
                string sql = @"select * from JobTitle;";
                var result = await _dapper.GetAllAsync<JobTitle>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getJobTitleById(string id)
        {
            try
            {
                string sql = @"select * from JobTitle WHERE JobTitleId = @Id";
                var result = await _dapper.GetByIdAsync<JobTitle>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getJobTitlesByName(string name)
        {
            try
            {
                string sql = @"select * from JobTitle where JobTitleName like '%" + name + "%'";
                var result = await _dapper.GetAllAsync<JobTitle>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
    }
}
