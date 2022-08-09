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
    public class TypeOfBankService : ITypeOfBankService
    {
        private readonly IDapperRepository _dapper;

        public TypeOfBankService(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<ReponsitoryModel> createTypeOfBank(TypeOfBank model)
        {
            try
            {
                if(model.TypeOfBankName == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Tên không được bỏ trống!" };

                var ExistsUserId = await _dapper.FindCloumnTAsync<Users>("TypeOfBank", "TypeOfBankName", model.TypeOfBankName);
                if (ExistsUserId != null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Bản ghi này đã tồn tại!" };
                model.CreatedAt = DateTime.Now;
                model.TypeOfBanklId = Guid.NewGuid().ToString();

                var sql = @"Insert into TypeOfBank(TypeOfBanklId,TypeOfBankName,CreatedAt) values(@TypeOfBanklId,@TypeOfBankName,,@CreatedAt)";

                var result = await _dapper.CreateTAsync<TypeOfBank>(sql, model);

                return new ReponsitoryModel { Data = result, StatusCode = 201, Message = "Thêm thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Tạo bản ghi thất bại!"};
            }
        }

        public async Task<ReponsitoryModel> getAllTypeOfBank()
        {
            try
            {
                string sql = @"select * from TypeOfBank;";
                var result = await _dapper.GetAllAsync<TypeOfBank>(sql);
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không có bản ghi nào!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getTypeOfBankById(string id)
        {
            try
            {
                string sql = @"select * from TypeOfBank WHERE TypeOfBankID = @Id";
                var result = await _dapper.GetByIdAsync<TypeOfBank>(sql, new { Id = id });
                if (result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin!" };
            }
        }

        public async Task<ReponsitoryModel> getTypeOfBanksByName(string name)
        {
            try
            {
                string sql = @"select * from TypeOfBank where TypeOfBankName like '%" + name + "%'";
                var result = await _dapper.GetAllAsync<TypeOfBank>(sql);
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
