using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;
using WebDomain.Models.UserModel;
using WebInfrastructure.Entities;

namespace WebDomain.Interfaces
{
    public interface IUserService
    {
        Task<ReponsitoryModel> getAllUser();
        Task<ReponsitoryModel> getAllUserByName(string name);
        Task<ReponsitoryModel> GetByIdAsync(string id);
        Task<ReponsitoryModel> CreateUserAsync(CreateUsersModel model);
        Task<ReponsitoryModel> UpdateUser(UpdateUserModel model, string id);
        Task<ReponsitoryModel> DeleteUser(string id);
    }
}
