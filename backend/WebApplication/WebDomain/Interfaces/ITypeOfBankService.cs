using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;
using WebInfrastructure.Entities;

namespace WebDomain.Interfaces
{
    public interface ITypeOfBankService
    {
        Task<ReponsitoryModel> getAllTypeOfBank();
        Task<ReponsitoryModel> getTypeOfBanksByName(string name);
        Task<ReponsitoryModel> getTypeOfBankById(string id);
        Task<ReponsitoryModel> createTypeOfBank(TypeOfBank model);
    }
}
