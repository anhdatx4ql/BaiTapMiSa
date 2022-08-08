using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IOriginService
    {
        Task<ReponsitoryModel> getAllOrigin();
        Task<ReponsitoryModel> getOriginsByName(string name);
        Task<ReponsitoryModel> getOriginById(string id);
    }
}
