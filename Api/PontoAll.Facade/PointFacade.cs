using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade
{
    public class PointFacade : IPointFacade
    {
        private readonly IPointFacade _pointService;
        private readonly IUserService _userService;

        public PointFacade(IPointFacade pointService, IUserService userService)
        {
            _pointService = pointService;
            _userService = userService;
        }

        public async Task<PointViewModel> RegisterPointAsync(PointInputModel pointInputModel, IEnumerable<Claim> claims)
        {
            var userEmail = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            if (userEmail == null) throw new Exception("Erro ao procurar usuário");

            var user = await _userService.FindUserByEmailAsync(userEmail);

            if (user == null) throw new Exception("Erro ao procurar usuário");





            throw new NotImplementedException();
        }
    }
}
