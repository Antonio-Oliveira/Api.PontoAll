using Microsoft.AspNetCore.Identity;
using PontoAll.Models.User;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }


        public async Task<SignInResult> SignInAsync(ApplicationUser user, string password)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

            return signInResult;
        }
    }
}
