using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Interfaces;
using WebDomain.Models;
using WebInfrastructure.Entities;
using WebInfrastructure.Repositories;

namespace WebDomain.Services
{
    public class UserFieldService : IUserFieldService
    {
        private readonly IDapperRepository _dapper;
        public UserFieldService(IDapperRepository dapper)
        {

            _dapper = dapper;
        }

        public async Task<ReponsitoryModel> CreateUserField(User_Field model)
        {
            try
            {
                if (model.FieldId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "FieldId không được bỏ trống!" };

                if (model.UserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User không được bỏ trống!" };

                // kiem tra id co ton tai hay khong
                var ExistsUserId = await _dapper.FindCloumnTAsync<Users>("Users", "UserId", model.UserId);
                if (ExistsUserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User này không tồn tại!" };


                // kiem tra id co ton tai hay khong
                var ExistsFieldId = await _dapper.FindCloumnTAsync<Users>("Fields", "FieldId", model.FieldId);
                if (ExistsFieldId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Lĩnh vực này không tồn tại!" };


                model.User_FieldId = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.Now;

                var sql = @"Insert into User_Field(User_FieldId,UserId,FieldId,CreatedAt) values(@User_FieldId,@UserId,@FieldId,@CreatedAt)";

                var result = await _dapper.CreateTAsync<User_Field>(sql, model);

                return new ReponsitoryModel { Data = result, StatusCode = 201, Message = "Thêm thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getAllUserField()
        {
            try
            {
                string sql = @"select * from User_Field;";
                var result = await _dapper.GetAllAsync<User_Field>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
        
        public async Task<ReponsitoryModel> getUserFieldByUserId(string id)
        {
            try
            {
                string sql = @"select * from User_Field WHERE UserId = @Id";
                var result = await _dapper.GetByIdAsync<User_Field>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getUserFieldsByFieldName(string FieldName)
        {
            try
            {
                string sql = @" select User_FieldId, Fields.FieldId,Fields.FieldName,UserId from User_Field inner join Fields on User_Field.FieldId = Fields.FieldId Where Fields.FieldName like '%"+ FieldName + "%' group by Fields.FieldId";
                var result = await _dapper.GetAllAsync<User_Field>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
    }
}
