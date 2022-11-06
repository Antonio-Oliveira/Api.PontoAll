using Microsoft.AspNetCore.Identity;
using PontoAll.Models.Auth;
using PontoAll.Models.User;
using PontoAll.Service.Data.Context;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Task<CollaboratorUser> FindUserByCPFAsync(string cpf)
        {
            var user = _context.Users.OfType<CollaboratorUser>().FirstOrDefault(u => u.CPF == cpf);

            return Task.FromResult(user);
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<IList<string>> GetRoleAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return roles;
        }

        public async Task<Guid> RegisterAddressAsync(Address address)
        {
            _context.Address.Add(address);

            await _context.SaveChangesAsync();

            return address.AddressId;
        }

        public async Task RegisterAdminAsync(ApplicationUser admin, string password)
        {
            var createAdmin = await _userManager.CreateAsync(admin, password);

            var adminRole = RoleEnum.Admin.ToString();

            if (createAdmin.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, adminRole);
            }
        }

        public async Task RegisterCollaboratorAsync(CollaboratorUser collaborator, string password, string role)
        {
            var createAdmin = await _userManager.CreateAsync(collaborator, password);

            if (!createAdmin.Succeeded)
            {
                throw new Exception("Erro ao criar usuário");
            }

            await _userManager.AddToRoleAsync(collaborator, role);
        }
    }
}
