using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;
using WebInfrastructure.Entities;

namespace WebDomain.Interfaces
{
    public interface IUserFieldService
    {
        Task<ReponsitoryModel> getAllUserField();
        Task<ReponsitoryModel> getUserFieldsByFieldName(string name);
        Task<ReponsitoryModel> getUserFieldByUserId(string id);
        Task<ReponsitoryModel> CreateUserField(User_Field model);
    }
}
