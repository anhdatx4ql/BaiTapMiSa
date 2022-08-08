using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IDepartmentService
    {
        Task<ReponsitoryModel> getAllDepartment();
        Task<ReponsitoryModel> getDepartmentsByName(string name);
        Task<ReponsitoryModel> getDepartmentsById(string id);
    }
}
