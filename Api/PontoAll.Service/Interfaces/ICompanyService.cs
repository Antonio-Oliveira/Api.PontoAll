using PontoAll.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> VerifyCompanyData(CompanyInputModel companyInputModel);

        Task RegisterCompany(Company company);

        Task RegisterCompanyAdmin();
    }
}
