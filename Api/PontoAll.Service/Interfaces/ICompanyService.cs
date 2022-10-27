using PontoAll.Models.Companys;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> FindCompanyByIdentityData(CompanyInputModel companyInputModel);

        Task RegisterCompany(Company company);

        Task RegisterCompanyAdmin(ApplicationUser admin, string password);
    }
}
