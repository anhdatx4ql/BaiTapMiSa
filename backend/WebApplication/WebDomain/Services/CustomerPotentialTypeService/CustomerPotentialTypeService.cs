using Common.Resources;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure;

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
                int count = 0;
                string strMessage = "";
                string sql = @"INSERT INTO CustomerPotentialType(CustomerPotentialTypeId,CustomerId,PotentialTypeId,CreatedAt,UpdatedAt) VALUES ";
                var dynamicParameters = new DynamicParameters();
                foreach (CreateCustomerPotentialTypeModel model in models)
                {

                    //Kiểm tra null mã khách hàng
                    if (model.CustomerId == null)
                        strMessage += "Mã khách hàng " + MessageError.NotExists + "\n";

                    // kiểm tra null mã loại tiềm năng
                    if (model.PotentialTypeId == null)
                        strMessage += "Mã lĩnh vực " + MessageError.NotExists + "\n";

                    // kiểm tra mã khách hàng có đúng hay không
                    var ExistsCustomer = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerId", model.CustomerId.ToString());


                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (ExistsCustomer == false)
                        strMessage += MessageError.NotValue + "\n";


                    // xóa hết dữ liệu hiện có liên quan đến customer : customerId
                    string sqlDelete = @"DELETE FROM customerpotentialtype WHERE CustomerId = @customerId";
                    var dynamicParametersDelete = new DynamicParameters();
                    dynamicParametersDelete.Add("customerId", model.CustomerId);
                    await _dapper.DeleteTAsync<CustomerPotentialType>(sqlDelete, dynamicParametersDelete);


                    // kiểm tra mã lĩnh vực có đúng hay không
                    if(model.PotentialTypeId != null)
                    {
                        var ExistsFieldId = await _dapper.FindCloumnTAsync<PotentialType>("PotentialType", "PotentialTypeId", model.PotentialTypeId);
                        if (ExistsFieldId == false)
                            strMessage += MessageError.NotValue + "\n";

                        count++;
                        if (count == 1)
                            sql += "(@CustomerPotentialTypeId" + count + ",@CustomerId" + count + ",@PotentialTypeId" + count + ",@CreatedAt" + count + ",@UpdatedAt" + count + ")";
                        else
                            sql += ",(@CustomerPotentialTypeId" + count + ",@CustomerId" + count + ",@PotentialTypeId" + count + ",@CreatedAt" + count + ",@UpdatedAt" + count + ")";
                        dynamicParameters.Add("CustomerPotentialTypeId" + count, Guid.NewGuid());
                        dynamicParameters.Add("CustomerId" + count, model.CustomerId);
                        dynamicParameters.Add("PotentialTypeId" + count, model.PotentialTypeId);
                        dynamicParameters.Add("CreatedAt" + count, DateTime.Now);
                        dynamicParameters.Add("UpdatedAt" + count, DateTime.Now);
                    }
                   

                }

                if(count > 0)
                {
                    var result = await _dapper.CreateMultipleAsync(sql, dynamicParameters);
                    if (result == 0)
                        return new ReponsitoryModel(null, CodeError.Code400, strMessage);

                    return new ReponsitoryModel(result, CodeSuccess.Status201, MessageSuccess.CreatedSuccess);
                }

                return new ReponsitoryModel(null, CodeSuccess.Status200, MessageSuccess.DeletedSuccess);

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel(ex.Message, CodeError.Code500, MessageError.ProcessError);
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
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.Code400 };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.Status200 };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.Code400 };
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
                string sql = @"SELECT PotentialType.PotentialTypeName, CustomerPotentialType.CustomerPotentialTypeId, CustomerPotentialType.CustomerId, CustomerPotentialType.PotentialTypeId FROM CustomerPotentialType INNER JOIN customer ON CustomerPotentialType.CustomerId = customer.CustomerId INNER JOIN PotentialType ON CustomerPotentialType.PotentialTypeId = PotentialType.PotentialTypeId WHERE PotentialType.PotentialTypeName LIKE @search OR customer.CustomerId LIKE @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{search}%"
                };
                var result = await _dapper.FindTAsync<CustomerPotentialTypeModel>(sql, parameters);
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
