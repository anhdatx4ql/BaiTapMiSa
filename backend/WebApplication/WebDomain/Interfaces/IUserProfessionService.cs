using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;
using WebInfrastructure.Entities;

namespace WebDomain.Interfaces
{
    public interface IUserProfessionService
    {
        Task<ReponsitoryModel> getAllUserProfession();
        Task<ReponsitoryModel> getUserProfessionsByName(string name);
        Task<ReponsitoryModel> getUserProfessionByUserId(string id);
        Task<ReponsitoryModel> CreateUserProfession(User_Profession model);
    }
}
