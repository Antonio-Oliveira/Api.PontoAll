using Microsoft.AspNetCore.Http;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade
{
    public class PointFacade : IPointFacade
    {
        //private readonly IPointService _pointService;
        private readonly IUserService _userService;

        public PointFacade(/*IPointService pointService,*/ IUserService userService)
        {
           // _pointService = pointService;
            _userService = userService;
        }

        public async Task<PointViewModel> RegisterPointAsync(PointInputModel pointInputModel, IEnumerable<Claim> claims)
        {
            var userEmail = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            if (userEmail == null) throw new Exception("Erro ao procurar usuário");

            var user = await _userService.FindUserByEmailAsync(userEmail);

            if (user == null) throw new Exception("Erro ao procurar usuário");

            var imageData = await ConvertImageToBase64(pointInputModel.UserPhotograph);

            

            //_pointService.RegisterPointAsync();


            throw new NotImplementedException();
        }

        private async Task<string> ConvertImageToBase64(IFormFile userPhotograph)
        {
            string filePath = Path.GetTempFileName();
            using (var stream = File.Create(filePath)) 
            {
                await userPhotograph.CopyToAsync(stream);
            }

            byte[] photographData = await File.ReadAllBytesAsync(filePath);

            var photographBase64 = Convert.ToBase64String(photographData);

            return photographBase64;
        }
    }
}
