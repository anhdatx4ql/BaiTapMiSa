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
    /// Service xử lý lĩnh vực khách hàng
    /// </summary>
    public class CustomerFieldService : ICustomerFieldService
    {

        private readonly IDapperRepository _dapper;

        public CustomerFieldService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// Created time: 2:58 15/08/222
        /// function: tạo mới lĩnh vực khách hàng
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> Create(CreateCustomerFieldModel[] models)
        {
            try
            {
                int[] results = { };
                int dem = 0;
                string sql = @"INSERT INTO customerfield(CustomerFieldId,CustomerId,FieldId,CreatedAt,UpdatedAt) VALUES ";
                var dynamicParameters = new DynamicParameters();
                foreach (CreateCustomerFieldModel model in models)
                {

                    //Kiểm tra null mã khách hàng
                    if (model.CustomerId == null)
                        return new ReponsitoryModel { Data = null, Message = "Mã khách hàng " + MessageError.NotExists };

                    // kiểm tra null mã lĩnh vực
                    if (model.FieldId == null)
                        return new ReponsitoryModel { Data = null, Message = "Mã lĩnh vực " + MessageError.NotExists };

                    // kiểm tra mã khách hàng có đúng hay không
                    var ExistsCustomerId = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerId", model.CustomerId.ToString());
                    if (ExistsCustomerId == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };


                    // kiểm tra mã lĩnh vực có đúng hay không
                    var ExistsFieldId = await _dapper.FindCloumnTAsync<Field>("Field", "FieldId", model.FieldId.ToString());

                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (ExistsFieldId == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicateValue, Message = MessageError.DuplicateValue };


                    // kiểm tra mã ngành nghề có đúng hay không
                    string sqlSearch = @"SELECT field.FieldName, customerfield.CustomerFieldId, customerfield.CustomerId, customerfield.FieldId FROM customerfield INNER JOIN customer ON customerfield.CustomerId = customer.CustomerId INNER JOIN field ON customerfield.FieldId = field.FieldId WHERE customerfield.FieldId = @FieldId and customerfield.CustomerId=@CustomerId;";
                    var parameters = new Dictionary<string, object>()
                    {
                        ["FieldId"] = $"%{model.FieldId}%",
                        ["CustomerId"] = $"%{model.CustomerId}%"
                    };

                    List<CustomerCareerModel> resultSqlSearch = await _dapper.FindTAsync<CustomerCareerModel>(sqlSearch, parameters);
                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (resultSqlSearch != null)
                    {

                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicateValue, Message = MessageError.DuplicateValue };

                    }

                    if (ExistsFieldId == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };
                    dem++;
                    if (models.Length == dem)
                        sql += "(@CustomerFieldId" + dem + ",@CustomerId" + dem + ",@FieldId" + dem + ",@CreatedAt" + dem + ",@UpdatedAt" + dem + ")";
                    else
                        sql += "(@CustomerFieldId" + dem + ",@CustomerId" + dem + ",@FieldId" + dem + ",@CreatedAt" + dem + ",@UpdatedAt" + dem + "),";
                    dynamicParameters.Add("CustomerFieldId" + dem, Guid.NewGuid());
                    dynamicParameters.Add("CustomerId" + dem, model.CustomerId);
                    dynamicParameters.Add("FieldId" + dem, model.FieldId);
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
        /// Author: Phạm Văn Đạt
        /// Created time: 2:59 15/08/222
        /// function: lấy danh sách lĩnh vực khách hàng
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT field.FieldName, customerfield.CustomerFieldId, customerfield.CustomerId, customerfield.FieldId FROM customerfield INNER JOIN customer ON customerfield.CustomerId = customer.CustomerId INNER JOIN field ON customerfield.FieldId = field.FieldId";

                var result = await _dapper.GetAllAsync<CustomerFieldModel>(sql);
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
        /// Author: Phạm Văn Đạt
        /// Created time: 2:58 15/08/222
        /// function: lấy danh sách lĩnh vực khách hàng theo tên tìm kiếm
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetByName(string search)
        {
            try
            {
                string sql = @"SELECT field.FieldName, customerfield.CustomerFieldId, customerfield.CustomerId, customerfield.FieldId FROM customerfield INNER JOIN customer ON customerfield.CustomerId = customer.CustomerId INNER JOIN field ON customerfield.FieldId = field.FieldId WHERE field.FieldName LIKE @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{search}%"
                };
                var result = await _dapper.FindTAsync<CustomerFieldModel>(sql, parameters);
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
