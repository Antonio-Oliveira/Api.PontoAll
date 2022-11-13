﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
using PontoAll.Models.Points;
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
        private readonly IPointService _pointService;
        private readonly IUserService _userService;

        public PointFacade(IPointService pointService, IUserService userService)
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

            var dateNow = DateTime.Now;

            var lastPointCurrentDate = await _pointService.VerifyLastPointCurrentDateAsync(dateNow);

            var typePoint = TypePointEnum.Entry;

            if (lastPointCurrentDate != null)
            {
                typePoint = lastPointCurrentDate.TypePoint.Equals(TypePointEnum.Entry) ? TypePointEnum.Exit : TypePointEnum.Entry;
            }

            var imageData = await ConvertImageToBase64Async(pointInputModel.UserPhotograph);

            var addressId = await CreateAddressPointAsync(pointInputModel.Address);

            var point = new Point()
            {
                AddressPointId = addressId,
                DatePoint = dateNow,
                PointId = Guid.NewGuid(),
                TypePoint = typePoint,
                UserPhotograph = imageData,
                UserId = user.Id
            };

            await _pointService.RegisterPointAsync(point);

            return new PointViewModel()
            {
                DatePoint = point.DatePoint,
                TypePoint = point.TypePoint.ToString()
            };
        }

        private async Task<Guid> CreateAddressPointAsync(AddressInputModel addressInputModel)
        {
            var addressPoint = new AddressPoint()
            {
                AddressPointId = Guid.NewGuid(),
                CEP = addressInputModel.CEP,
                City = addressInputModel.City,
                Country = addressInputModel.Country,
                District = addressInputModel.District,
                Number = addressInputModel.Number,
                Reference = string.IsNullOrEmpty(addressInputModel.Reference) ? null : addressInputModel.Reference,
                State = addressInputModel.State,
                Street = addressInputModel.Street
            };

            var addressId = await _pointService.RegisterAddressPointAsync(addressPoint);

            return addressId;
        }

        private IFormFile ConvertBase64ToImageAsync(string imageBase64)
        {
            byte[] bytes = Convert.FromBase64String(imageBase64);

            MemoryStream stream = new MemoryStream(bytes);

            var imageName = Guid.NewGuid().ToString();

            IFormFile file = new FormFile(stream, 0, bytes.Length, imageName, imageName);

            return file;
        }

        private async Task<string> ConvertImageToBase64Async(IFormFile userPhotograph)
        {
            await using var memoryStream = new MemoryStream();

            await userPhotograph.CopyToAsync(memoryStream);

            var fileBytes = memoryStream.ToArray();

            var photographBase64 = Convert.ToBase64String(fileBytes);

            return photographBase64;

            /*
            string filePath = Path.GetTempFileName();
            using (var stream = File.Create(filePath))
            {
                await userPhotograph.CopyToAsync(stream);
            }

            byte[] photographData = await File.ReadAllBytesAsync(filePath);

            var photographBase64 = Convert.ToBase64String(photographData);
            return photographBase64;
            */
        }

        public async Task<PointViewModel> GetCurrentPointAsync(IEnumerable<Claim> claims)
        {
            var dateNow = DateTime.Now;

            var emailManager = GetEmailByClaim(claims);

            if (emailManager == null) throw new Exception("Erro ao procurar usuário");

            var user = await _userService.FindUserByEmailAsync(emailManager);

            if (emailManager == null) throw new Exception("Erro ao procurar usuário");

            var currentPoint = await _pointService.GetCurrentPointAsync(dateNow);

            var pointViewModel = new PointViewModel()
            {
                DatePoint = currentPoint.DatePoint,
                TypePoint = currentPoint.TypePoint.ToString()
            };

            return pointViewModel;
        }

        private string GetEmailByClaim(IEnumerable<Claim> claims) => claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
    }
}
