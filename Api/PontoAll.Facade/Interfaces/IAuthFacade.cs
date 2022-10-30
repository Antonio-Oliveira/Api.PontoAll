using PontoAll.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade.Interfaces
{
    public interface IAuthFacade
    {
        Task<string> Login(LoginInputModel userInputModel);
    }
}
