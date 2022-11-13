using Microsoft.AspNetCore.Identity;
using PontoAll.Models.Auth;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAdminAsync(ApplicationUser admin, string password);

        Task RegisterCollaboratorAsync(CollaboratorUser collaborator, string password, string role);

        Task<ApplicationUser> FindUserByEmailAsync(string email);

        Task<IList<string>> GetRoleAsync(ApplicationUser user);

        Task<CollaboratorUser> FindUserByCPFAsync(string cpf);

        Task<Guid> RegisterAddressAsync(Address address);

        Task<List<CollaboratorUser>> GetUserByCompanyIdAsync(Guid companyId);
    }
}
