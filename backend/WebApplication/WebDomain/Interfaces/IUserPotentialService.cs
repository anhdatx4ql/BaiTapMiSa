using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;
using WebInfrastructure.Entities;

namespace WebDomain.Interfaces
{
    public interface IUserPotentialService
    {
        Task<ReponsitoryModel> getAllUserPotential();
        Task<ReponsitoryModel> getUserPotentialsByPotentialName(string PotentialName);
        Task<ReponsitoryModel> getUserPotentialByUserId(string UserId);
        Task<ReponsitoryModel> CreateUserPotential(User_Potential model);
    }
}
