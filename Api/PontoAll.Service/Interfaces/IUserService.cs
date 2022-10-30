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
    }
}
