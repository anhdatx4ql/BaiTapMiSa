using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IProfessionsService
    {
        Task<ReponsitoryModel> getAllProfessions();
        Task<ReponsitoryModel> getProfessionsByName(string name);
        Task<ReponsitoryModel> getProfessionById(string id);
    }
}
