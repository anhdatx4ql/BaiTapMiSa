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
    /// Created Time: 4:36 15/08/2022
    /// function: Service xử lý bảng loại hình tổ chức
    /// </summary>
    public class OrganizationTypeService: IOrganizationTypeService
    {
        private readonly IDapperRepository _dapper;
        public OrganizationTypeService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT OrganizationTypeId,OrganizationTypeName FROM OrganizationType";
                List<OrganizationTypeModel> result = await _dapper.GetAllAsync<OrganizationTypeModel>(sql);
                if (result.Count == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.Code400 };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.Code400 };
            }
        }

        public async Task<ReponsitoryModel> GetAllByName(string name)
        {
            try
            {
                string sql = @"SELECT OrganizationTypeId,OrganizationTypeName FROM OrganizationType WHERE OrganizationTypeName like '%" + name + "%';";

                List<OrganizationTypeModel> result = await _dapper.GetAllAsync<OrganizationTypeModel>(sql);
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
