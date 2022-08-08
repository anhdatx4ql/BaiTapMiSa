using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IFieldService
    {
        Task<ReponsitoryModel> getAllField();
        Task<ReponsitoryModel> getFieldsByName(string name);
        Task<ReponsitoryModel> getFieldById(string id);
    }
}
