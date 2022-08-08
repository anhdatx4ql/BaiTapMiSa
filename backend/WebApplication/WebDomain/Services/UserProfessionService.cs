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
    public class UserProfessionService : IUserProfessionService
    {
        private readonly IDapperRepository _dapper;
        public UserProfessionService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<ReponsitoryModel> CreateUserProfession(User_Profession model)
        {
            try
            {
                if (model.ProfessionId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "ProfessionId không được bỏ trống!" };

                if (model.UserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User không được bỏ trống!" };

                // kiem tra id co ton tai hay khong
                var ExistsUserId = await _dapper.FindCloumnTAsync<Users>("Users", "UserId", model.UserId);
                if (ExistsUserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "User này không tồn tại!" };


                // kiem tra id co ton tai hay khong
                var ExistsFieldId = await _dapper.FindCloumnTAsync<Professions>("Professions", "ProfessionId", model.ProfessionId);
                if (ExistsFieldId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Nghề nghiệp này không tồn tại!" };


                model.User_ProfessionId = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.Now;

                var sql = @"Insert into User_Profession(User_ProfessionId,UserId,ProfessionId,CreatedAt) values(@User_ProfessionId,@UserId,@ProfessionId,@CreatedAt)";

                var result = await _dapper.CreateTAsync<User_Profession>(sql, model);

                return new ReponsitoryModel { Data = result, StatusCode = 201, Message = "Thêm thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getAllUserProfession()
        {
            try
            {
                string sql = @"select * from User_Profession;";
                var result = await _dapper.GetAllAsync<User_Profession>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getUserProfessionByUserId(string UserId)
        {
            try
            {
                string sql = @"select * from User_Profession WHERE UserId = @Id";
                var result = await _dapper.GetByIdAsync<User_Profession>(sql, new { Id = UserId });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + UserId + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getUserProfessionsByName(string ProfessionName)
        {
            try
            {
                string sql = @" select User_PotentialId, Potential.PotentialId,Potential.PotentialName,UserId from User_Potential inner join Fields on User_Potential.PotentialId = Potential.PotentialId Where Potential.PotentialName like '%" + ProfessionName + "%' group by Potential.PotentialId";
                var result = await _dapper.GetAllAsync<User_Profession>(sql);
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
