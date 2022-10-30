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
            await _userRepository.RegisterAdminForCompany(admin, password);
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userRepository.FindUserByEmailAsync(email);

            return user;
        }
    }
}
