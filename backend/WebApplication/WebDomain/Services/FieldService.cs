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
    public class FieldService : IFieldService
    {
        private readonly IDapperRepository _dapper;
        public FieldService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<ReponsitoryModel> getAllField()
        {
            try
            {
                string sql = @"select * from Fields;";
                var result = await _dapper.GetAllAsync<Fields>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getFieldById(string id)
        {
            try
            {
                string sql = @"select * from Fields WHERE FieldId = @Id";
                var result = await _dapper.GetByIdAsync<Fields>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getFieldsByName(string name)
        {
            try
            {
                string sql = @"select * from Fields where FieldName like '%" + name + "%'";
                var result = await _dapper.GetAllAsync<Fields>(sql);
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
