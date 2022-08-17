using Dapper;
using System;
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
    /// Author:Phạm văn Đạt
    /// Created: 2:56 15/08/2022
    /// Service xử lý tiềm năng khách hàng
    /// </summary>
    public class CustomerPotentialTypeService : ICustomerPotentialTypeService
    {
        private readonly IDapperRepository _dapper;

        public CustomerPotentialTypeService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// function: thêm mới bản ghi
        /// Created time: 4:09 15/08/2022
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> Create(CreateCustomerPotentialTypeModel[] models)
        {
            try
            {
                int[] results = { };
                int dem = 0;
                string sql = @"INSERT INTO CustomerPotentialType(CustomerPotentialTypeId,CustomerId,PotentialTypeId,CreatedAt,UpdatedAt) VALUES ";
                var dynamicParameters = new DynamicParameters();
                foreach (CreateCustomerPotentialTypeModel model in models)
                {

                    //Kiểm tra null mã khách hàng
                    if (model.CustomerId == null)
                        return new ReponsitoryModel { Data = null, Message = "Mã khách hàng " + MessageError.NotExists };

                    // kiểm tra null mã lĩnh vực
                    if (model.PotentialTypeId == null)
                        return new ReponsitoryModel { Data = null, Message = "Mã lĩnh vực " + MessageError.NotExists };

                    // kiểm tra mã khách hàng có đúng hay không
                    var ExistsCustomer = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerId", model.CustomerId.ToString());


                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (ExistsCustomer == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };

                    // kiểm tra mã lĩnh vực có đúng hay không
                    var ExistsFieldId = await _dapper.FindCloumnTAsync<Field>("PotentialType", "PotentialTypeId", model.PotentialTypeId.ToString());
                    if (ExistsFieldId == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };


                    // kiểm tra mã ngành nghề có đúng hay không
                    string sqlSearch = @"SELECT PotentialType.PotentialTypeName, CustomerPotentialType.CustomerPotentialTypeId, CustomerPotentialType.CustomerId, CustomerPotentialType.PotentialTypeId FROM CustomerPotentialType INNER JOIN customer ON CustomerPotentialType.CustomerId = customer.CustomerId INNER JOIN PotentialType ON CustomerPotentialType.PotentialTypeId = PotentialType.PotentialTypeId WHERE CustomerPotentialType.PotentialTypeId = @PotentialTypeId and CustomerPotentialType.CustomerId=@CustomerId;";
                    var parameters = new Dictionary<string, object>()
                    {
                        ["PotentialTypeId"] = $"%{model.PotentialTypeId}%",
                        ["CustomerId"] = $"%{model.CustomerId}%"
                    };

                    List<CustomerCareerModel> resultSqlSearch = await _dapper.FindTAsync<CustomerCareerModel>(sqlSearch, parameters);
                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (resultSqlSearch != null)
                    {

                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicateValue, Message = MessageError.DuplicateValue };

                    }


                    dem++;
                    if (models.Length == dem)
                        sql += "(@CustomerFieldId" + dem + ",@CustomerId" + dem + ",@FieldId" + dem + ",@CreatedAt" + dem + ",@UpdatedAt" + dem + ")";
                    else
                        sql += "(@CustomerFieldId" + dem + ",@CustomerId" + dem + ",@FieldId" + dem + ",@CreatedAt" + dem + ",@UpdatedAt" + dem + "),";
                    dynamicParameters.Add("CustomerFieldId" + dem, Guid.NewGuid());
                    dynamicParameters.Add("CustomerId" + dem, model.CustomerId);
                    dynamicParameters.Add("FieldId" + dem, model.PotentialTypeId);
                    dynamicParameters.Add("CreatedAt" + dem, DateTime.Now);
                    dynamicParameters.Add("UpdatedAt" + dem, DateTime.Now);
                }

                var result = await _dapper.CreateMultipleAsync(sql, dynamicParameters);
                if (result == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.CreatedFail, StatusCode = CodeError.CreateFailed };

                return new ReponsitoryModel { Data = result, Message = MessageSuccess.CreatedSuccess, StatusCode = CodeSuccess.CreatedSuccess };

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }

        /// <summary>
        ///  Author: Phạm Văn Đạt
        /// function: hiển thị bản ghi
        /// Created time: 4:09 15/08/2022
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT PotentialType.PotentialTypeName, CustomerPotentialType.CustomerPotentialTypeId, CustomerPotentialType.CustomerId, CustomerPotentialType.PotentialTypeId FROM CustomerPotentialType INNER JOIN customer ON CustomerPotentialType.CustomerId = customer.CustomerId INNER JOIN PotentialType ON CustomerPotentialType.PotentialTypeId = PotentialType.PotentialTypeId";

                var result = await _dapper.GetAllAsync<CustomerPotentialTypeModel>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }


        /// <summary>
        ///  Author: Phạm Văn Đạt
        /// function: hiển thị bản ghi theo tên
        /// Created time: 4:09 15/08/2022
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetByName(string search)
        {
            try
            {
                string sql = @"SELECT PotentialType.PotentialTypeName, CustomerPotentialType.CustomerPotentialTypeId, CustomerPotentialType.CustomerId, CustomerPotentialType.PotentialTypeId FROM CustomerPotentialType INNER JOIN customer ON CustomerPotentialType.CustomerId = customer.CustomerId INNER JOIN PotentialType ON CustomerPotentialType.PotentialTypeId = PotentialType.PotentialTypeId WHERE PotentialType.PotentialTypeName LIKE @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{search}%"
                };
                var result = await _dapper.FindTAsync<CustomerPotentialTypeModel>(sql, parameters);
                if (result == null)
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
