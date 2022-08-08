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
    public class RevenuesService : IRevenuesService
    {

        private readonly IDapperRepository _dapper;

        public RevenuesService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<ReponsitoryModel> getAllRevenue()
        {
            try
            {
                string sql = @"select * from Revenues;";
                var result = await _dapper.GetAllAsync<Revenues>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
        

        public async Task<ReponsitoryModel> getRevenueById(string id)
        {
            try
            {
                string sql = @"select * from Revenues WHERE RevenueId = @Id";
                var result = await _dapper.GetByIdAsync<Revenues>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
        
        public async Task<ReponsitoryModel> getRevenuesByName(string name)
        {
            try
            {
                string sql = @"select * from Revenues where RevenueName like '%" + name + "%'";
                var result = await _dapper.GetAllAsync<Revenues>(sql);
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
