using PontoAll.Models.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Guid> RegisterCompany(Company company);

        Task<List<Company>> FindCompanyByIdentityData(CompanyInputModel companyInputModel);
    }
}
