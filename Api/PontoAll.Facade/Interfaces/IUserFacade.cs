using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade.Interfaces
{
    public interface IUserFacade
    {
        Task RegisterAdminForCompanyAsync(CompanyInputModel companyInputModel, Guid companyId);

        Task<CollaboratorViewModel> RegisterCollaboradorAsync(CollaboratorInputModel collaboratorInputModel, IEnumerable<Claim> claims);

        Task<List<CollaboratorViewModel>> GetCollaboradorAsync(IEnumerable<Claim> claims);
    }
}
