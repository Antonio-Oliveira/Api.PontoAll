using Microsoft.AspNetCore.Http;
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
using System.Text.RegularExpressions;
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

            var lastPointCurrentDate = await _pointService.VerifyLastPointCurrentDateAsync(dateNow, user.Id);

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
                TypePoint = point.TypePoint.ToString(),
                UserPhotograph = point.UserPhotograph
            };
        }

        private string ClearDocument(string document)
        {
            string pattern = @"(?i)[\-*\.*\\*\/*\s*]";

            string replacement = string.Empty;

            Regex rgx = new Regex(pattern);

            string cleanDocument = rgx.Replace(document, replacement);

            return cleanDocument;
        }


        private async Task<Guid> CreateAddressPointAsync(AddressInputModel addressInputModel)
        {
            var addressPoint = new AddressPoint()
            {
                AddressPointId = Guid.NewGuid(),
                CEP = ClearDocument(addressInputModel.CEP),
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

        private FormFile ConvertBase64ToImage(string imageBase64)
        {
            byte[] bytes = Convert.FromBase64String(imageBase64);
            MemoryStream stream = new MemoryStream(bytes);

            var name = Guid.NewGuid().ToString();

            FormFile file = new FormFile(stream, 0, bytes.Length, name, name);

            return file;
        }

        public async Task<PointViewModel> GetCurrentPointAsync(IEnumerable<Claim> claims)
        {
            var dateNow = DateTime.Now;

            var emailManager = GetEmailByClaim(claims);

            if (emailManager == null) throw new Exception("Erro ao procurar usuário");

            var user = await _userService.FindUserByEmailAsync(emailManager);

            if (user == null) throw new Exception("Erro ao procurar usuário");

            var currentPoint = await _pointService.GetCurrentPointAsync(dateNow, user.Id);

            if (currentPoint == null) return null;

            var pointViewModel = new PointViewModel()
            {
                DatePoint = currentPoint.DatePoint,
                TypePoint = currentPoint.TypePoint.ToString(),
                UserPhotograph = currentPoint.UserPhotograph
            };

            return pointViewModel;
        }

        private string GetEmailByClaim(IEnumerable<Claim> claims) => claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

        public async Task<UserPointViewModel> GetPointsAsync(IEnumerable<Claim> claims)
        {
            var emailManager = GetEmailByClaim(claims);

            if (emailManager == null) throw new Exception("Erro ao procurar usuário");

            var user = await _userService.FindUserByEmailAsync(emailManager);

            if (user == null) throw new Exception("Erro ao procurar usuário");

            var points = await _pointService.GetPointsAsync(user.Id);

            var pointsViewModel = points.Select(point => new PointViewModel()
            {
                DatePoint = point.DatePoint,
                TypePoint = point.TypePoint.ToString(),
                UserPhotograph = point.UserPhotograph
            }).ToList();

            var overtime = CalculateOvertimeAsync(points);

            return new UserPointViewModel()
            {
                Overtime = overtime,
                Points = pointsViewModel
            };
        }

        public async Task<UserPointViewModel> GetCollaboratorPointsAsync(string collaboratorEmail)
        {
            var points = await _pointService.GetCollaboratorPointsAsync(collaboratorEmail);

            var overtimeUser = CalculateOvertimeAsync(points);

            var pointsViewModel = points.Select(point => new PointViewModel()
            {
                DatePoint = point.DatePoint,
                TypePoint = point.TypePoint.ToString(),
                UserPhotograph = point.UserPhotograph
            }).ToList();

            return new UserPointViewModel()
            {
                Overtime = overtimeUser,
                Points = pointsViewModel
            };
        }

        private string CalculateOvertimeAsync(List<Point> points)
        {
            if (points.Count is default(int)) return "00:00";

            var listParPoints = points.Where(p => p.DatePoint < DateTime.Now.Date).GroupBy(p => p.DatePoint.Date).ToList();

            double sumOvertime = 0;

            for (int i = 0; i < listParPoints.Count(); i++)
            {
                var parPoints = listParPoints[i].ToList();

                double sumParPoints = 0;

                if (parPoints.Count > default(int))
                {
                    for (int j = 0; (j + 1) < parPoints.Count(); j += 2)
                    {
                        sumParPoints += parPoints[j].DatePoint.Subtract(parPoints[j + 1].DatePoint).TotalHours;
                    }
                    sumOvertime += sumParPoints - 8;
                }
            }

            var overtimeSpan = TimeSpan.FromHours(sumOvertime);
            var typeOvertime = overtimeSpan.Hours >= 0 ? string.Empty : "-";
            var overtimeHours = overtimeSpan.Hours >= 0 ? overtimeSpan.Hours : overtimeSpan.Hours * -1;
            var overtimeMinutes = overtimeSpan.Minutes >= 0 ? overtimeSpan.Minutes : overtimeSpan.Minutes * -1;

            var overtimeHoursString = overtimeHours > 10 ? overtimeHours.ToString() : $"0{overtimeHours}";
            var overtimeMinutesString = overtimeMinutes > 10 ? overtimeMinutes.ToString() : $"0{overtimeMinutes}";

            return $"{typeOvertime}{overtimeHoursString}:{overtimeMinutesString}";
        }
    }
}
