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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDapperRepository _dapper;
        public DepartmentService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }


        public async Task<ReponsitoryModel> getAllDepartment()
        {
            try
            {
                string sql = @"select * from Department;";
                var result = await _dapper.GetAllAsync<Department>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getDepartmentsByName(string name)
        {
            try
            {
                string sql = @"select * from Department where departmentName like '%" + name + "%'";
                var result = await _dapper.GetAllAsync<Department>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getDepartmentsById(string id)
        {
            try
            {
                string sql = @"select * from Department WHERE DepartmentID = @Id";
                var result = await _dapper.GetByIdAsync<Department>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
    }
}
