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
    /// Created Time: 11:23 13/08/2022
    /// Service xử lý bảng phòng ban
    /// </summary>
    public class DepartmentService : IDepartmentService
    {

        private readonly IDapperRepository _dapper;
        public DepartmentService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 11:25 13/08/2022
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT DepartmentId,DepartmentName FROM Department";
                List<DepartmentModel> result = await _dapper.GetAllAsync<DepartmentModel>(sql);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.Code400 };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.Code400 };
            }
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 11:25 13/08/2022
        /// Lấy danh sách phòng ban theo tên
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAllByName(string name)
        {
            try
            {
                string sql = @"SELECT DepartmentId,DepartmentName FROM Department WHERE DepartmentName like @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{name}%"
                };
                List<DepartmentModel> result = await _dapper.FindTAsync<DepartmentModel>(sql, parameters);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.Code400 };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.Code400 };
            }
        }
    }
}
