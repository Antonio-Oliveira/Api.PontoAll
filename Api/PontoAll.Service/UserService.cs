using Microsoft.AspNetCore.Identity;
using PontoAll.Models.Auth;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAdminForCompany(ApplicationUser admin, string password)
        {
            await _userRepository.RegisterAdminAsync(admin, password);
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userRepository.FindUserByEmailAsync(email);

            return user;
        }

        public async Task<IList<string>> GetRoleAsync(ApplicationUser user)
        {
            var role = await _userRepository.GetRoleAsync(user);

            return role;
        }

        public async Task<ApplicationUser> FindUserByCPFAsync(string cpf)
        {
            var user = await _userRepository.FindUserByCPFAsync(cpf);

            return user;
        }

        public async Task RegisterCollaboratorAsync(CollaboratorUser user, string password, string role)
        {
            await _userRepository.RegisterCollaboratorAsync(user, password, role);
        }

        public async Task<Guid> RegisterAddressAsync(Address address)
        {
            var addressId = await _userRepository.RegisterAddressAsync(address);

            return addressId;
        }

        public async Task<List<CollaboratorUser>> GetUserByCompanyIdAsync(Guid companyId)
        {
            var collaborators = await _userRepository.GetUserByCompanyIdAsync(companyId);

            return collaborators;
        }
    }
}
