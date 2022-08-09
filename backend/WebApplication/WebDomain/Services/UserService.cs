using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Interfaces;
using WebDomain.Models;
using WebDomain.Models.UserModel;
using WebInfrastructure.Entities;
using WebInfrastructure.Repositories;

namespace WebDomain.Services
{
    public class UserService : IUserService
    {
        private readonly IDapperRepository _dapper;

        public UserService(IDapperRepository dapper)
        {
            _dapper = dapper;
 
        }

        public async Task<ReponsitoryModel> getAllUser()
        {
            try
            {
                string sql = @" SELECT UserId, FirstName, LastName, FullName, UserNumberPhone, CompanyNumberPhone, UserEmail, "
                    + "CompanyEmail, Zalo, TaxCode, Organize, Gender, BirthDay, UserDescription, Address, Country, City, "
                    + "District, Commune, ApartmentNumber, AreaCode, BankAccount, OpenAtBank,DateBank, FaceBook, IsUserPhoneActive, "
                    + "ISUserEmailActive, Users.VocativeId, Users.DepartMentID, Users.OriginId, Users.JobTitleId, "
                    + "Users.RevenueId, Users.TypeOfBankId, users.CreatedAt, "
                    + "users.UpdatedAt, VocativeName, DepartmentName, OriginName, JobTitleName, RevenueName, TypeOfBankName FROM users "
                    + "LEFT JOIN vocative ON users.VocativeId = vocative.VocativeId "
                    + "LEFT JOIN Department ON users.DepartmentID = Department.DepartmentID "
                    + "LEFT JOIN Origin ON users.OriginId = Origin.OriginId "
                    + "LEFT JOIN JobTitle ON users.JobTitleId = JobTitle.JobTitleId "
                    + "LEFT JOIN Revenues ON users.RevenueID = Revenues.RevenueID "
                    + "LEFT JOIN TypeOfBank ON users.TypeOfBankId = TypeOfBank.TypeOfBanklId";
                var result = await _dapper.GetAllAsync<UserModel>(sql);
                if(result == null)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message ="Không có bản ghi nào!" };
                return new ReponsitoryModel {Data= result, StatusCode = 200, Message="Lấy thông tin người dùng thành công!" };

            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin người dùng!" };
            }

        }

        //lấy tất cả các user có tên trong bảng
        public async Task<ReponsitoryModel> getAllUserByName(string name)
        {
            try
            {
                string sql = @" SELECT UserId, FirstName, LastName, FullName, UserNumberPhone, CompanyNumberPhone, UserEmail, "
                      + "CompanyEmail, Zalo, TaxCode, Organize, Gender, BirthDay, UserDescription, Address, Country, City, "
                      + "District, Commune, ApartmentNumber, AreaCode, BankAccount, OpenAtBank,DateBank, FaceBook, IsUserPhoneActive, "
                      + "ISUserEmailActive, Users.VocativeId, Users.DepartMentID, Users.OriginId, Users.JobTitleId, "
                      + "Users.RevenueId, Users.TypeOfBankId, users.CreatedAt, "
                      + "users.UpdatedAt, VocativeName, DepartmentName, OriginName, JobTitleName, RevenueName, TypeOfBankName FROM users "
                      + "LEFT JOIN vocative ON users.VocativeId = vocative.VocativeId "
                      + "LEFT JOIN Department ON users.DepartmentID = Department.DepartmentID "
                      + "LEFT JOIN Origin ON users.OriginId = Origin.OriginId "
                      + "LEFT JOIN JobTitle ON users.JobTitleId = JobTitle.JobTitleId "
                      + "LEFT JOIN Revenues ON users.RevenueID = Revenues.RevenueID "
                      + "LEFT JOIN TypeOfBank ON users.TypeOfBankId = TypeOfBank.TypeOfBanklId  where FullName like '%" + name + "%'";
               
                var result = await _dapper.GetTByNameAsync<UserModel>(sql);
                if(result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại người dùng có tên "+name+"!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy người dùng thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin người dùng!" };
            }

        }


        // lấy user chứa Id
        public async Task<ReponsitoryModel> GetByIdAsync(string id)
        {
            try
            {
                string sql = @" SELECT UserId, FirstName, LastName, FullName, UserNumberPhone, CompanyNumberPhone, UserEmail, "
                     + "CompanyEmail, Zalo, TaxCode, Organize, Gender, BirthDay, UserDescription, Address, Country, City, "
                     + "District, Commune, ApartmentNumber, AreaCode, BankAccount, OpenAtBank,DateBank, FaceBook, IsUserPhoneActive, "
                     + "ISUserEmailActive, Users.VocativeId, Users.DepartMentID, Users.OriginId, Users.JobTitleId, "
                     + "Users.RevenueId, Users.TypeOfBankId, users.CreatedAt, "
                     + "users.UpdatedAt, VocativeName, DepartmentName, OriginName, JobTitleName, RevenueName, TypeOfBankName FROM users "
                     + "LEFT JOIN vocative ON users.VocativeId = vocative.VocativeId "
                     + "LEFT JOIN Department ON users.DepartmentID = Department.DepartmentID "
                     + "LEFT JOIN Origin ON users.OriginId = Origin.OriginId "
                     + "LEFT JOIN JobTitle ON users.JobTitleId = JobTitle.JobTitleId "
                     + "LEFT JOIN Revenues ON users.RevenueID = Revenues.RevenueID "
                     + "LEFT JOIN TypeOfBank ON users.TypeOfBankId = TypeOfBank.TypeOfBanklId  WHERE UserId = @Id";
                var result = await _dapper.GetByIdAsync<UserModel>(sql, new { Id = id });
                if(result == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại người dùng có id = "+id+" này!" };
                return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };
            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không lấy được thông tin người dùng!" };
            }

        }

        // tạo bảng mới / dang sai
        public async Task<ReponsitoryModel> CreateUserAsync(CreateUsersModel model)
        {
            try
            {
                if(model.UserId == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Mã tiềm năng không được bỏ trống!" };

                //string sql = @"select MAX(users.UserId) from users";
                //var result = await _dapper.GetByIdAsync<Department>(sql, new { Id = id });
                //if (result == null)
                //    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại phòng ban có id = " + id + " này!" };
                //return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Lấy thông tin thành công!" };

                // Xử lý trùng Id

                var ExistsUserID = await _dapper.FindCloumnTAsync<Users>("Users", "UserId", model.UserId);
                   if (ExistsUserID != null)
                       return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Mã tiềm năng này đã có người sử dụng" };


                if (model.LastName == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Tên không được bỏ trống!" };

                // Xử lý trùng UserNummberPhone
                if (model.UserNumberPhone != null)
                {
                    var ExistsUserPhone = await _dapper.FindCloumnTAsync<Users>("Users", "UserNumberPhone", model.UserNumberPhone);
                    if (ExistsUserPhone != null)
                        return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Số điện thoại này đã có người sử dụng" };
                }

                // xử lý trùng email
                if (model.UserEmail != null)
                {
                    var ExistsUserEmail = await _dapper.FindCloumnTAsync<Users>("Users", "UserEmail", model.UserEmail);
                    if (ExistsUserEmail != null)
                        return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Email này đã có người sử dụng!" };

                }

                string sql = @"Insert into Users(UserId, FirstName, LastName, FullName,
                            UserNumberPhone, CompanyNumberPhone, UserEmail, CompanyEmail, Zalo,
                            TaxCode, Organize, UserDescription, Address, Country, City, District,
                            Commune, ApartmentNumber, AreaCode, BankAccount, OpenAtBank, DateBank,
                            VocativeId, DepartmentID, OriginId, JobTitleId, RevenueID)
                             VALUES(@UserId, @FirstName, @LastName, @FullName, @UserNumberPhone,
                            @CompanyNumberPhone, @UserEmail, @CompanyEmail, @Zalo,
                            @TaxCode, @Organize, @UserDescription,@Address,@Country, @City,@District,
                            @Commune, @ApartmentNumber, @AreaCode, @BankAccount, 
                            @OpenAtBank, @DateBank, @VocativeId, @DepartmentID, @OriginId, @JobTitleId, @RevenueID);";
                Users user = new Users
                {
                    UserId = model.UserId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    UserNumberPhone = model.UserNumberPhone,
                    CompanyNumberPhone = model.CompanyNumberPhone,
                    UserEmail = model.UserEmail,
                    CompanyEmail = model.CompanyEmail,
                    Zalo = model.Zalo,
                    TaxCode = model.TaxCode,
                    Organize = model.Organize,
                    UserDescription = model.UserDescription,
                    Address = model.Address,
                    Country = model.Country,
                    City = model.City,
                    District = model.District,
                    Commune = model.Commune,
                    ApartmentNumber = model.ApartmentNumber,
                    AreaCode = model.AreaCode,
                    BankAccount = model.BankAccount,
                    OpenAtBank = model.OpenAtBank,
                    DateBank = model.DateBank,
                    VocativeId = model.VocativeId,
                    DepartmentID = model.DepartmentID,
                    OriginId = model.OriginId,
                    JobTitleId = model.JobTitleId,
                    RevenueID = model.RevenueID,
                    CreatedAt = DateTime.Now
                };
                var result = await _dapper.CreateTAsync<Users>(sql, user);
                return new ReponsitoryModel { Data = result, StatusCode = 201, Message = "Thêm thông tin thành công!" };


            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Không tạo được user!" };
            }
        }

        // hàm xử lý cập nhật user -- lamf lai
        public async Task<ReponsitoryModel> UpdateUser(UpdateUserModel model, string id)
        {
            try
            {
                string sql = @" SELECT UserId, FirstName, LastName, FullName, UserNumberPhone, CompanyNumberPhone, UserEmail, "
                    + "CompanyEmail, Zalo, TaxCode, Organize, Gender, BirthDay, UserDescription, Address, Country, City, "
                    + "District, Commune, ApartmentNumber, AreaCode, BankAccount, OpenAtBank,DateBank, FaceBook, IsUserPhoneActive, "
                    + "ISUserEmailActive, Users.VocativeId, Users.DepartMentID, Users.OriginId, Users.JobTitleId, "
                    + "Users.RevenueId, Users.TypeOfBankId, users.CreatedAt, "
                    + "users.UpdatedAt, VocativeName, DepartmentName, OriginName, JobTitleName, RevenueName, TypeOfBankName FROM users "
                    + "LEFT JOIN vocative ON users.VocativeId = vocative.VocativeId "
                    + "LEFT JOIN Department ON users.DepartmentID = Department.DepartmentID "
                    + "LEFT JOIN Origin ON users.OriginId = Origin.OriginId "
                    + "LEFT JOIN JobTitle ON users.JobTitleId = JobTitle.JobTitleId "
                    + "LEFT JOIN Revenues ON users.RevenueID = Revenues.RevenueID "
                    + "LEFT JOIN TypeOfBank ON users.TypeOfBankId = TypeOfBank.TypeOfBanklId WHERE UserId = @Id";
                var user = await _dapper.GetByIdAsync<Users>(sql, new { Id = id });
                if (user == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại người dùng có id = " + id + " này!" };

                // THAY ĐỔI DỮ LIỆU TRONG BẢNG
                if (model.FirstName != null)
                    user.FirstName = model.FirstName;

                if(model.LastName != null)
                    user.LastName = model.LastName;

                if(model.FullName != null)
                    user.FullName = model.FullName;

                if(model.UserNumberPhone != null)
                {
                    var ExistsUserPhone = await _dapper.FindCloumnTAsync<Users>("Users", "UserNummberPhone", model.UserNumberPhone);
                    if (ExistsUserPhone != null)
                        return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Số điện thoại này đã có người sử dụng" };
                    user.UserNumberPhone = model.UserNumberPhone;
                }
                    

                if (model.CompanyNumberPhone != null)
                    user.UserNumberPhone = model.UserNumberPhone;


                // chưa xử lý email trùng với email khác
                if (model.UserEmail != null)
                {
                    var ExistsUserEmail = await _dapper.FindCloumnTAsync<Users>("Users", "UserEmail", model.UserEmail);
                    if(ExistsUserEmail != null)
                        return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Email này đã có người sử dụng!" };
                    user.UserEmail = model.UserEmail;
                    
                }
                    

                if (model.CompanyEmail != null)
                    user.CompanyEmail = model.CompanyEmail;

                if (model.Zalo != null)
                    user.Zalo = model.Zalo;

                if (model.TaxCode != null)
                    user.TaxCode = model.TaxCode;

                if (model.Organize != null)
                    user.Organize = model.Organize;

                if (model.Gender)
                    user.Gender = model.Gender;

                if (model.BirthDay != null)
                    user.BirthDay = model.BirthDay;

                if (model.Facebook != null)
                    user.Facebook = model.Facebook;

                if (model.IsUserPhoneActive)
                    user.IsUserPhoneActive = model.IsUserPhoneActive;

                if (model.IsUserEmailActive)
                    user.IsUserEmailActive = model.IsUserEmailActive;

                if (model.VocativeId != null)
                    user.VocativeId = model.VocativeId;

                if (model.DepartmentID != null)
                    user.DepartmentID = model.DepartmentID;

                if (model.OriginId != null)
                    user.OriginId = model.OriginId;

                if (model.JobTitleId != null)
                    user.JobTitleId = model.JobTitleId;

                if (model.RevenueID != null)
                    user.RevenueID = model.RevenueID;


                user.UpdatedAt = DateTime.Now;

                // lấy ra được user
                // tạo câu truy vấn:
                var sqlUpdate = @"UPDATE Users SET FirstName = @FirstName, LastName =@LastName, FullName = @FullName,UserNumberPhone = @UserNumberPhone, CompanyNumberPhone = @CompanyNumberPhone,UserEmail = @UserEmail , CompanyEmail= @CompanyEmail, Zalo = @Zalo,TaxCode=@TaxCode, Organize=@Organize,Gender=@Gender, BirthDay=@BirthDay,Facebook =@Facebook,IsUserPhoneActive=@IsUserPhoneActive, IsUserEmailActive=@IsUserEmailActive,VocativeId=@VocativeId, DepartmentID=@DepartmentID, OriginId=@OriginId,JobTitleId=@JobTitleId, RevenueID=@RevenueID,UpdatedAt=@UpdatedAt WHERE UserId = @UserId;";
                var result = await _dapper.UpdateTAsync<Users>(sqlUpdate, user);

                if (result == 1)
                    return new ReponsitoryModel { Data = user, StatusCode = 200, Message = "Update thành công!" };

                return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Update thất bại!" };
            }
    
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Có lỗi trong quá trình xử lý!" };
            }
        }

        // hàm xóa thông tin user, chuyển IsDelete = true
        public async Task<ReponsitoryModel> DeleteUser(string id)
        {
            try {
                if (id == null)
                {
                    return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Id không được bỏ trống!" };
                }
                string sql = @"select * from Users WHERE UserId = @Id";
                var user = await _dapper.GetByIdAsync<Users>(sql, new { Id = id });
                if (user == null)
                    return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Không tồn tại người dùng có id = " + id + " này!" };

                user.UpdatedAt = DateTime.Now;

                // lấy ra được user
                // tạo câu truy vấn:
                var sqlUpdate = @"UPDATE Users SET IsDelete=true, UpdatedAt=@UpdatedAt WHERE UserId = @UserId;";
                var result = await _dapper.UpdateTAsync<Users>(sqlUpdate, user);

                if (result == 1)
                    return new ReponsitoryModel { Data = result, StatusCode = 200, Message = "Xóa user thành công!" };

                return new ReponsitoryModel { Data = null, StatusCode = 200, Message = "Xóa user thất bại!" };


            }
            catch
            {
                return new ReponsitoryModel { Data = null, StatusCode = 400, Message = "Có lỗi trong quá trình xử lý" };
            }
            
        }

    }
}
