using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IRevenuesService
    {
        Task<ReponsitoryModel> getAllRevenue();
        Task<ReponsitoryModel> getRevenuesByName(string name);
        Task<ReponsitoryModel> getRevenueById(string id);
    }
}
