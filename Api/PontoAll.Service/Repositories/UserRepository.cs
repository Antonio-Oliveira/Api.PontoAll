using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task RegisterAdminForCompany(ApplicationUser admin, string password)
        {
            var createAdmin = await _userManager.CreateAsync(admin, password);

            if (createAdmin.Succeeded)
            {
                // Atribui o usuário ao perfil Admin
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
