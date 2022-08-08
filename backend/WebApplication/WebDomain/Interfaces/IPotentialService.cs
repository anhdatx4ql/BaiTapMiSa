using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IPotentialService
    {
        Task<ReponsitoryModel> getAllPotential();
        Task<ReponsitoryModel> getPotentialsByName(string name);
        Task<ReponsitoryModel> getPotentialById(string id);
    }
}
