using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IJobTitleService
    {
        Task<ReponsitoryModel> getAllJobTitle();
        Task<ReponsitoryModel> getJobTitlesByName(string name);
        Task<ReponsitoryModel> getJobTitleById(string id);
    }
}
