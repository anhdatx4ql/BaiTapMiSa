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
    public class CustomerDetailService : ICustomerDetailService
    {
        private readonly IDapperRepository _dapper;
        public CustomerDetailService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<ReponsitoryModel> GetAll()
        {
            try
            {
                string sql = @"SELECT * FROM CustomerDetail";

                var result = await _dapper.GetAllAsync<CustomerDetail>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }

        public async Task<ReponsitoryModel> GetsByCustomerId(string CustomerId)
        {
            try
            {
                string sql = @"SELECT * FROM CustomerDetail WHERE CustomerId = @CustomerId;";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("CustomerId", CustomerId);
                var result = await _dapper.GetAllAsync<CustomerDetailModel>(sql, dynamicParameters);
                if (result.Count ==0)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };

            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }

        public async Task<ReponsitoryModel> GetsByName(string search)
        {
            try
            {
                string sql = @"SELECT * FROM CustomerDetail WHERE CustomerDetailName like @search;";
                var parameters = new Dictionary<string, object>()
                {
                    ["search"] = $"%{search}%"
                };
                var result = await _dapper.FindTAsync<Career>(sql, parameters);
                if (result == null)
                    return new ReponsitoryModel { Data = null, Message = MessageError.NotValue, StatusCode = CodeError.NotValue };
                return new ReponsitoryModel { Data = result, Message = MessageSuccess.GetSuccess, StatusCode = CodeSuccess.GetSuccess };
            }
            catch (Exception ex)
            {
                return new ReponsitoryModel { Data = ex.Message, Message = MessageError.ProcessError, StatusCode = CodeError.ProcessError };
            }
        }
    }
}
