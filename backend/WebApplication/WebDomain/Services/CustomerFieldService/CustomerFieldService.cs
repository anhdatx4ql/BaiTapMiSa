using Dapper;
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
                int count = 0;
                string sql = @"INSERT INTO customerfield(CustomerFieldId,CustomerId,FieldId,CreatedAt,UpdatedAt) VALUES ";
                var dynamicParameters = new DynamicParameters();
                foreach (CreateCustomerFieldModel model in models)
                {

                    //Kiểm tra null mã khách hàng
                    if (model.CustomerId == null)
                        return new ReponsitoryModel(null, CodeError.Code400, "Mã khách hàng " + MessageError.NotExists);

                    // kiểm tra null mã lĩnh vực
                    if (model.FieldId == null)
                        return new ReponsitoryModel(null, CodeError.Code400, "Mã lĩnh vực " + MessageError.NotExists);

                    // kiểm tra mã khách hàng có đúng hay không
                    var ExistsCustomerId = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerId", model.CustomerId.ToString());
                    if (ExistsCustomerId == false)
                        return new ReponsitoryModel(null, CodeError.Code400, MessageError.NotValue);


                    // xóa hết dữ liệu hiện có liên quan đến customer : customerId
                    string sqlDelete = @"DELETE FROM CustomerField WHERE CustomerId = @customerId";
                    var dynamicParametersDelete = new DynamicParameters();
                    dynamicParametersDelete.Add("customerId", model.CustomerId);
                    await _dapper.DeleteTAsync<CustomerField>(sqlDelete, dynamicParametersDelete);


                    // kiểm tra mã lĩnh vực có đúng hay không
                    var ExistsFieldId = await _dapper.FindCloumnTAsync<Field>("Field", "FieldId", model.FieldId.ToString());

                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (ExistsFieldId == false)
                        return new ReponsitoryModel(null, CodeError.Code400, MessageError.DuplicateValue);

                        count++;
                        if (count == 1)
                            sql += "(@CustomerFieldId" + count + ",@CustomerId" + count + ",@FieldId" + count + ",@CreatedAt" + count + ",@UpdatedAt" + count + ")";
                        else
                            sql += ",(@CustomerFieldId" + count + ",@CustomerId" + count + ",@FieldId" + count + ",@CreatedAt" + count + ",@UpdatedAt" + count + ")";
                        dynamicParameters.Add("CustomerFieldId" + count, Guid.NewGuid());
                        dynamicParameters.Add("CustomerId" + count, model.CustomerId);
                        dynamicParameters.Add("FieldId" + count, model.FieldId);
                        dynamicParameters.Add("CreatedAt" + count, DateTime.Now);
                        dynamicParameters.Add("UpdatedAt" + count, DateTime.Now);
                  
                }

               
                var result = await _dapper.CreateMultipleAsync(sql, dynamicParameters);
                if (result == 0)
                    return new ReponsitoryModel(null,CodeError.Code400 ,MessageError.CreatedFail);


                return new ReponsitoryModel(result, CodeSuccess.Status201, MessageSuccess.CreatedSuccess);



            }
            catch (Exception ex)
            {
                return new ReponsitoryModel(ex.Message, CodeError.Code400, MessageError.ProcessError);
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
                    return new ReponsitoryModel(null, CodeError.Code400, MessageError.NotValue);
                return new ReponsitoryModel(result, CodeSuccess.Status200, MessageSuccess.GetSuccess);
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel(ex.Message, CodeError.Code400, MessageError.ProcessError);
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
                string sql = @"SELECT field.FieldName, customerfield.CustomerFieldId, customerfield.CustomerId, customerfield.FieldId FROM customerfield INNER JOIN customer ON customerfield.CustomerId = customer.CustomerId INNER JOIN field ON customerfield.FieldId = field.FieldId WHERE field.FieldName LIKE @search OR customerfield.CustomerId LIKE @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{search}%"
                };
                var result = await _dapper.FindTAsync<CustomerFieldModel>(sql, parameters);
                if (result == null)
                    return new ReponsitoryModel(null, CodeError.Code400, MessageError.NotValue);
                return new ReponsitoryModel(result, CodeSuccess.Status200, MessageSuccess.GetSuccess);
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel(ex.Message, CodeError.Code400, MessageError.ProcessError);
            }
        }
    }
}
