using Microsoft.AspNetCore.Identity;
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
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<SignInResult> SignInAsync(ApplicationUser user, string password)
        {
            var signInResult = await _authRepository.SignInAsync(user, password);

            return signInResult;
        }
    }
}
