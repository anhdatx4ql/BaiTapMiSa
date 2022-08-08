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
    public class UserPotentialService : IUserPotentialService
    {
        private readonly IDapperRepository _dapper;
        public UserPotentialService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<ReponsitoryModel> getAllUserPotential()
        {
            try
            {
                string sql = @"select * from User_Potential;";
                var result = await _dapper.GetAllAsync<User_Potential>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getUserPotentialByUserId(string UserId)
        {
            try
            {
                string sql = @"select * from User_Potential WHERE UserId = @Id";
                var result = await _dapper.GetByIdAsync<User_Potential>(sql, new { Id = UserId });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + UserId + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        // timf kieems loai tiem nang
        public async Task<ReponsitoryModel> getUserPotentialsByPotentialName(string PotentialName)
        {
            try
            {
                string sql = @" select User_PotentialId, Potential.PotentialId,Potential.PotentialName,UserId from User_Potential inner join Fields on User_Potential.PotentialId = Potential.PotentialId Where Potential.PotentialName like '%" + PotentialName + "%' group by Potential.PotentialId";
                var result = await _dapper.GetAllAsync<User_Potential>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }


        public async Task<ReponsitoryModel> CreateUserPotential(User_Potential model)
        {
            try
            {
                if (model.PotentialId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "PotentialId không được bỏ trống!" };

                if (model.UserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User không được bỏ trống!" };

                // kiem tra id co ton tai hay khong
                var ExistsUserId = await _dapper.FindCloumnTAsync<Users>("Users", "UserId", model.UserId);
                if (ExistsUserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User này không tồn tại!" };


                // kiem tra id co ton tai hay khong
                var ExistsFieldId = await _dapper.FindCloumnTAsync<Users>("Potential", "PotentialId", model.PotentialId);
                if (ExistsFieldId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Lĩnh vực này không tồn tại!" };


                model.User_PotentialID = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.Now;

                var sql = @"Insert into User_Potential(User_PotentialId,UserId,PotentialId,CreatedAt) values(@User_PotentialId,@UserId,@PotentialId,@CreatedAt)";

                var result = await _dapper.CreateTAsync<User_Potential>(sql, model);

                return new ReponsitoryModel { Data = result, StatusCode = 201, Message = "Thêm thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

    }
    
}
