using Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;

namespace WebDomain
{
    public class PotentialTypeService : IPotentialTypeService
    {
        private readonly IDapperRepository _dapper;

        public PotentialTypeService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// function: Lấy danh sách
        /// Created time: 5:55 15/08/2022
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT PotentialTypeId,PotentialTypeName FROM PotentialType";
                List<PotentialTypeModel> result = await _dapper.GetAllAsync<PotentialTypeModel>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.Code400 };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.Code500 };
            }
        }


        /// <summary>
        /// Author: Phạm Văn Đạt
        /// function: Lấy danh sách theo tên
        /// Created time: 5:55 15/08/2022
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAllByName(string name)
        {
            try
            {
                string sql = @"SELECT PotentialTypeId,PotentialTypeName FROM PotentialType WHERE PotentialTypeName like @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{name}%"
                };
                List<PotentialTypeModel> result = await _dapper.FindTAsync<PotentialTypeModel>(sql, parameters);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.Code400 };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.Code500 };
            }
        }
    }
}
