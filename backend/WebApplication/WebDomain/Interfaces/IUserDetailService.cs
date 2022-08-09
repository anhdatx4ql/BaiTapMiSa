using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;
using WebInfrastructure.Entities;

namespace WebDomain.Interfaces
{
    public interface IUserDetailService
    {
        Task<ReponsitoryModel> getAllUserDetail();
        Task<ReponsitoryModel> getUserDetailByUserDetailName(string name);
        Task<ReponsitoryModel> getUserDetailByUserId(string id);
        Task<ReponsitoryModel> CreateUserDetail(UserDetail model);
    }
}
