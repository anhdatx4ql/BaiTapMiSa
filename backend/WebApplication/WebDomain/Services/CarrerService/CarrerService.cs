using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;
using static Common.ContantsError;
using static Common.ContantsSuccess;

namespace WebDomain
{

    /// <summary>
    /// Author:Phạm văn Đạt
    /// Created: 8:03 13:08:2022
    /// Service xử lý  ngành nghề
    /// </summary>
    public class CarrerService : ICarrerService
    {
        private readonly IDapperRepository _dapper;
        public CarrerService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// CreatedAt: 9:17 13/08/2022
        /// lấy danh sách ngành nghề
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAllCarrer()
        {
            try
            {
                string sql = @"SELECT * FROM Career";

                var result = await _dapper.GetAllAsync<Career>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }
        

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// CraetedAt: 9:17 13/08/2022
        /// lấy danh sách ngành nghề theo tên
        /// </summary>
        /// <param name="_search"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetCarrerByName(string _search)
        {
            try
            {
                string sql = @"SELECT * FROM Career WHERE CareerName like @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{_search}%"
                };
                var result = await _dapper.FindTAsync<Career>(sql, parameters);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }
    }
}
