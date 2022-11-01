using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
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

        Task<CollaboratorViewModel> RegisterCollaborador(CollaboratorInputModel collaboratorInputModel);
    }
}
