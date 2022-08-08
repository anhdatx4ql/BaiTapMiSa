using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDomain.Models;

namespace WebDomain.Interfaces
{
    public interface IVocativeService
    {
        Task<ReponsitoryModel> getAllVocative();
        Task<ReponsitoryModel> getVocativesByName(string name);
        Task<ReponsitoryModel> getVocativeById(string id);
    }
}
