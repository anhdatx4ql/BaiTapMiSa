﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;
using static WebDomain.ContantsError;
using static WebDomain.ContantsSuccess;

namespace WebDomain
{
    /// <summary>
    /// Author: Phạm Văn Đạt
    /// Created Time:19:34 13/08/2022
    /// Service xử lý bảng nguồn gốc
    /// </summary>
    public class SourceService: ISourceService
    {
        private readonly IDapperRepository _dapper;
        public SourceService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 19:35 13/08/2022
        /// Lấy danh sách nguồn gốc
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT SourceId,SourceName FROM source";
                List<SourceModel> result = await _dapper.GetAllAsync<SourceModel>(sql);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created Time: 19:35 13/08/2022
        /// Lấy danh sách tiềm năng theo tên
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAllByName(string name)
        {
            try
            {
                string sql = @"SELECT SourceId,SourceName FROM source WHERE SourceName like @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{name}%"
                };
                List<SourceModel> result = await _dapper.FindTAsync<SourceModel>(sql, parameters);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }

    }
}
