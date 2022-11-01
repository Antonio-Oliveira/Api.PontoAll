using Microsoft.AspNetCore.Identity;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> SignInAsync(ApplicationUser user, string password);

    }
}

