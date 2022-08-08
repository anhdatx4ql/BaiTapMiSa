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
    public class PotentialService : IPotentialService
    {
        private readonly IDapperRepository _dapper;

        public PotentialService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<ReponsitoryModel> getAllPotential()
        {
            try
            {
                string sql = @"select * from Potential;";
                var result = await _dapper.GetAllAsync<Potential>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
        

        public async Task<ReponsitoryModel> getPotentialById(string id)
        {
            try
            {
                string sql = @"select * from Potential WHERE PotentialId = @Id";
                var result = await _dapper.GetByIdAsync<Potential>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getPotentialsByName(string name)
        {
            try
            {
                string sql = @"select * from Potential where PotentialName like '%" + name + "%'";
                var result = await _dapper.GetAllAsync<Potential>(sql);
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
