using PontoAll.Facade.Interfaces;
using PontoAll.Models.Companys;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;

        public UserFacade(IUserService userService)
        {
            _userService = userService;
        }

        public async Task RegisterAdminForCompany(CompanyInputModel companyInputModel, Guid companyId)
        {
            var admin = new ApplicationUser()
            {
                Email = companyInputModel.Email,
                UserName = companyInputModel.FantasyName,
                CompanyId = companyId
            };

            var password = companyInputModel.Password;

            await _userService.RegisterAdminForCompany(admin, password);
        }
    }
}
