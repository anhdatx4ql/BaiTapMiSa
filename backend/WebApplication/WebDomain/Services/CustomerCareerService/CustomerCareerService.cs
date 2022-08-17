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
                string sql = @"SELECT customercareer.CustomerCareerId, customercareer.CustomerId, customercareer.CareerID, career.CareerName FROM customercareer INNER JOIN career ON customercareer.CareerID = career.CareerId INNER JOIN customer ON customercareer.CustomerId = customer.CustomerId";

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
                string sql = @"SELECT customercareer.CustomerCareerId, customercareer.CustomerId, customercareer.CareerID, career.CareerName FROM customercareer INNER JOIN career ON customercareer.CareerID = career.CareerId INNER JOIN customer ON customercareer.CustomerId = customer.CustomerId WHERE career.CareerName LIKE @search;";
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
        /// chưa check xem customerId và FieldID có trùng trong bảng hay không. bằng cách lấy ra id user trong bảng có fieldId, so sánh nếu trùng thì bỏ qua không thêm
        /// </summary>
        /// <param CustomerCareer="model"></param>
        /// <returns></returns>
        public async Task<ReponsitoryModel> Create(CreateCustomerCareerModel[] models)
        {
            try 
            {
                int[] results = { };
                int dem = 0;
                string sql = @"INSERT INTO customercareer(CustomerCareerId,CustomerId,CareerID,CreatedAt,UpdatedAt) VALUES ";
                var dynamicParameters = new DynamicParameters();
                foreach (CreateCustomerCareerModel model in models)
                {
                   
                        //Kiểm tra null mã khách hàng
                        if (model.CustomerId == null)
                            return new ReponsitoryModel { Data = null, Message = "Mã khách hàng " + MessageError.NotExists };

                        // kiểm tra null mã ngành nghề
                        if (model.CareerID == null)
                            return new ReponsitoryModel { Data = null, Message = "Mã ngành nghề " + MessageError.NotExists };

                        // kiểm tra mã khách hàng có đúng hay không
                        var ExistsCustomerId = await _dapper.FindCloumnTAsync<Customer>("Customer", "CustomerId", model.CustomerId.ToString());
                        if (ExistsCustomerId == null)
                            return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };
                        
                        // kiểm tra mã khách hàng có đúng hay không
                        var ExistsCareerId = await _dapper.FindCloumnTAsync<Career>("Career", "CareerId", model.CareerID.ToString());
                        if (ExistsCareerId == null)
                            return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };


                    // kiểm tra mã ngành nghề có đúng hay không
                    string sqlSearch = @"SELECT customercareer.CustomerCareerId, customercareer.CustomerId, customercareer.CareerID, career.CareerName FROM customercareer INNER JOIN career ON customercareer.CareerID = career.CareerId INNER JOIN customer ON customercareer.CustomerId = customer.CustomerId WHERE customercareer.CareerID = @CareerID and customercareer.CustomerId=@CustomerId;";
                    var parameters = new Dictionary<string, object>()
                    {
                        ["CareerID"] = $"%{model.CareerID}%",
                        ["CustomerId"] = $"%{model.CustomerId}%"
                    };
                   
                    List<CustomerCareerModel> resultSqlSearch = await _dapper.FindTAsync<CustomerCareerModel>(sqlSearch, parameters);
                    // kiếm tra dòng dữ liệu này đã tồn tại chưa
                    if (resultSqlSearch != null)
                    {
                        
                        return new ReponsitoryModel { Data = null, StatusCode = CodeError.DuplicateValue, Message = MessageError.DuplicateValue };

                    }

                    if (ExistsCareerId == null)
                            return new ReponsitoryModel { Data = null, StatusCode = CodeError.NotValue, Message = MessageError.NotValue };
                        dem++;
                        if(models.Length == dem)
                            sql += "(@CustomerCareerId"+dem+ ",@CustomerId" + dem + ",@CareerID" + dem + ",@CreatedAt" + dem + ",@UpdatedAt" + dem + ")";
                        else
                            sql += "(@CustomerCareerId" + dem + ",@CustomerId" + dem + ",@CareerID" + dem + ",@CreatedAt" + dem + ",@UpdatedAt" + dem + "),";
                        dynamicParameters.Add("CustomerCareerId" + dem, Guid.NewGuid());
                        dynamicParameters.Add("CustomerId" + dem, model.CustomerId);
                        dynamicParameters.Add("CareerID" + dem, model.CareerID);
                        dynamicParameters.Add("CreatedAt" + dem, DateTime.Now);
                        dynamicParameters.Add("UpdatedAt" + dem, DateTime.Now);
                }

                var result = await _dapper.CreateMultipleAsync(sql, dynamicParameters);
                if(result == 0)
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
