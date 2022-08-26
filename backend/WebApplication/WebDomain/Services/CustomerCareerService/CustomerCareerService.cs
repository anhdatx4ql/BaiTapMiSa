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
    /// Created: 8:03 13:08:2022
    /// Service xử lý  ngành nghề khách hàng
    /// </summary>
    public class CustomerCareerService : ICustomerCareerService
    {
        private readonly IDapperRepository _dapper;
        public CustomerCareerService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// Author: Phạm Văn Đạt
        /// CreatedAt: 9:20 13/08/2022
        /// </summary>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT customercareer.CustomerCareerId, customercareer.CustomerId, customercareer.CareerId, career.CareerName FROM customercareer INNER JOIN career ON customercareer.CareerId = career.CareerId INNER JOIN customer ON customercareer.CustomerId = customer.CustomerId";

                var result = await _dapper.GetAllAsync<CustomerCareerModel>(sql);
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
        /// CraetedAt: 9:17 13/08/2022
        /// lấy danh sách ngành nghề khách hàng theo tên
        /// </summary>
        /// <param name="_search"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> GetByName(string search)
        {
            try
            {
                string sql = @"SELECT customercareer.CustomerCareerId, customercareer.CustomerId, customercareer.CareerId, career.CareerName FROM customercareer INNER JOIN career ON customercareer.CareerId = career.CareerId INNER JOIN customer ON customercareer.CustomerId = customer.CustomerId WHERE career.CareerName LIKE @search OR customer.CustomerId LIKE @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{search}%"
                };
                var result = await _dapper.FindTAsync<CustomerCareerModel>(sql, parameters);
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
        /// funciton: Tạo mới ngành nghề người dùng
        /// chưa check xem customerId và FieldID có trùng trong bảng hay không. bằng cách lấy ra Id user trong bảng có fieldId, so sánh nếu trùng thì bỏ qua không thêm
        /// </summary>
        /// <param CustomerCareer="model"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> Create(CreateCustomerCareerModel[] models)
        {
            try 
            {
                int[] results = { };
                int count = 0;
                string sql = @"INSERT INTO customercareer(CustomerCareerId,CustomerId,CareerId,CreatedAt,UpdatedAt) VALUES ";
                var dynamicParameters = new DynamicParameters();

                foreach (CreateCustomerCareerModel model in models)
                {

                    //Kiểm tra null mã khách hàng
                    if (model.CustomerId == null)
                        return new ReponsitoryModel { Data = null, Message = "Mã khách hàng " + MessageError.NotExists };

                    // kiểm tra null mã ngành nghề
                    if (model.CareerId == null)
                        return new ReponsitoryModel { Data = null, Message = "Mã ngành nghề " + MessageError.NotExists };

                    // kiểm tra mã khách hàng có đúng hay không
                    var ExistsCustomerId = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerId", model.CustomerId.ToString());
                    if (ExistsCustomerId == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };


                    // xóa hết dữ liệu hiện có liên quan đến customer : customerId
                    string sqlDelete = @"DELETE FROM CustomerCareer WHERE CustomerId = @customerId";
                    var dynamicParametersDelete = new DynamicParameters();
                    dynamicParametersDelete.Add("customerId", model.CustomerId);
                    await _dapper.DeleteTAsync<CustomerCareer>(sqlDelete, dynamicParametersDelete);


                    // kiểm tra mã ngành nghề có đúng hay không
                    var ExistsCareerId = await _dapper.FindCloumnTAsync<Career>("Career", "CareerId", model.CareerId.ToString());
                    if (ExistsCareerId == null)
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };



                        count++;
                        if (count == 1)
                            sql += "(@CustomerCareerId" + count + ",@CustomerId" + count + ",@CareerId" + count + ",@CreatedAt" + count + ",@UpdatedAt" + count + ")";
                        else
                            sql += ",(@CustomerCareerId" + count + ",@CustomerId" + count + ",@CareerId" + count + ",@CreatedAt" + count + ",@UpdatedAt" + count + ")";
                        dynamicParameters.Add("CustomerCareerId" + count, Guid.NewGuid());
                        dynamicParameters.Add("CustomerId" + count, model.CustomerId);
                        dynamicParameters.Add("CareerId" + count, model.CareerId);
                        dynamicParameters.Add("CreatedAt" + count, DateTime.Now);
                        dynamicParameters.Add("UpdatedAt" + count, DateTime.Now);
                    

                }

                var result = await _dapper.CreateMultipleAsync(sql, dynamicParameters);
                if (result == 0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.CreatedFail, StatusCode = CodeError.CreateFailed };

                return new ReponsitoryModel { Data = result, Message = MessageSuccess.CreatedSuccess, StatusCode = CodeSuccess.CreatedSuccess };

            }
            catch(Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }
    }
}
