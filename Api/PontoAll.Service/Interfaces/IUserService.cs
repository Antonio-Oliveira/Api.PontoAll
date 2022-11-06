using Microsoft.AspNetCore.Identity;
using PontoAll.Models.Auth;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Interfaces
{
    public interface IUserService
    {
        Task RegisterAdminForCompany(ApplicationUser admin, string password);

        Task<ApplicationUser> FindUserByEmailAsync(string email);

        Task<IList<string>> GetRoleAsync(ApplicationUser user);

        Task<ApplicationUser> FindUserByCPFAsync(string cpf);

        Task RegisterCollaboratorAsync(CollaboratorUser user, string password, string role);

        Task<Guid> RegisterAddressAsync(Address address);
    }
}
