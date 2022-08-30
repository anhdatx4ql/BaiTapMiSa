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
    /// Author: Phạm Văn Đạt
    /// Created Time: 6:15 15/08/2022
    /// Service xử lý bảng doanh thu
    /// </summary>
    public class TurnoverService : ITurnoverService
    {
        private readonly IDapperRepository _dapper;
        public TurnoverService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 19:35 13/08/2022
        /// Lấy danh sách doanh thu
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT TurnoverId,TurnoverName FROM Turnover ORDER BY TurnoverName ASC;";
                List<TurnoverModel> result = await _dapper.GetAllAsync<TurnoverModel>(sql);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 19:35 13/08/2022
        /// Lấy danh sách doanh thu theo tên
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAllByName(string name)
        {
            try
            {
                string sql = @"SELECT TurnoverId,TurnoverName FROM Turnover WHERE TurnoverName like @search ORDER BY TurnoverName ASC;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{name}%"
                };
                List<TurnoverModel> result = await _dapper.FindTAsync<TurnoverModel>(sql, parameters);
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
