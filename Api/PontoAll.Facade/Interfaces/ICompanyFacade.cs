using PontoAll.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade.Interfaces
{
    public interface ICompanyFacade
    {
        Task RegisterCompany(CompanyInputModel companyInputModel);
    }
}
