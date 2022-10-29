using PontoAll.Models.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade.Interfaces
{
    public interface IUserFacade
    {
        Task RegisterAdminForCompany(CompanyInputModel companyInputModel, Guid companyId);
    }
}
