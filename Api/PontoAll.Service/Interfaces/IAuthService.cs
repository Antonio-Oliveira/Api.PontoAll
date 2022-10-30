using Microsoft.AspNetCore.Identity;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> SignInAsync(ApplicationUser user, string password);
    }
}
