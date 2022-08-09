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
    public class UserDetailService: IUserDetailService
    {
        private readonly IDapperRepository _dapper;
        public UserDetailService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<ReponsitoryModel> CreateUserDetail(UserDetail model)
        {
            try
            {
                if (model.UserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "UserId không được bỏ trống!" };

                // kiem tra id co ton tai hay khong
                var ExistsUserId = await _dapper.FindCloumnTAsync<Users>("Users", "UserId", model.UserId);
                if (ExistsUserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User này không tồn tại!" };


                model.UserDetailID = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.Now;

                var sql = @"Insert into UserDetail(UserDetailID,UserId,UserDetailName,CreatedAt) values(@UserDetailID,@UserId,@UserDetailName,@CreatedAt)";

                var result = await _dapper.CreateTAsync<UserDetail>(sql, model);

                return new ReponsitoryModel { Data = result, StatusCode = 201, Message = "Thêm thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getAllUserDetail()
        {
            try
            {
                string sql = @"select * from UserDetail;";
                var result = await _dapper.GetAllAsync<UserDetail>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getUserDetailByUserDetailName(string name)
        {
            try
            {
                string sql = @" select * from User_Field Where UserDetailName like '%" + name + "%'";
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

        public async Task<ReponsitoryModel> getUserDetailByUserId(string id)
        {
            try
            {
                string sql = @"select * from UserDetail WHERE UserId = @Id";
                var result = await _dapper.GetByIdAsync<UserDetail>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại bản ghi có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }
    }
}
