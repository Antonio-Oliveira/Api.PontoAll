using Microsoft.AspNetCore.Http;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Auth;
using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task RegisterAdminForCompanyAsync(CompanyInputModel companyInputModel, Guid companyId)
        {
            var username = CreateUsername(companyInputModel.FantasyName, companyInputModel.CNPJ);

            var admin = new ApplicationUser()
            {
                Email = companyInputModel.Email,
                UserName = companyInputModel.FantasyName,
                CompanyId = companyId
            };

            var password = companyInputModel.Password;

            await _userService.RegisterAdminForCompany(admin, password);
        }

        public async Task<CollaboratorViewModel> RegisterCollaboradorAsync(CollaboratorInputModel collaboratorInputModel, IEnumerable<Claim> claims)
        {
            var manager = await FindManagerAsync(claims);

            if (manager == null) throw new Exception("Erro ao procurar manager");

            var verifyUserForEmail = await _userService.FindUserByEmailAsync(collaboratorInputModel.Email);

            if (verifyUserForEmail != null) throw new Exception("Usuário já existe com Email solicitado");

            var verifyUserForCpf = await _userService.FindUserByCPFAsync(collaboratorInputModel.CPF);

            if (verifyUserForCpf != null) throw new Exception("Usuário já existe com CPF solicitado");

            var addressId = await CreateAddressAsync(collaboratorInputModel.Address);

            var companyId = manager.CompanyId;

            var cleanCpf = ClearDocument(collaboratorInputModel.CPF);

            var username = CreateUsername(collaboratorInputModel.Name, cleanCpf);

            var user = new CollaboratorUser()
            {
                BirthDate = collaboratorInputModel.BirthDate,
                Email = collaboratorInputModel.Email,
                PhoneNumber = collaboratorInputModel.PhoneNumber,
                FullName = collaboratorInputModel.Name,
                CPF = cleanCpf,
                UserName = username,
                AddressId = addressId,
                CompanyId = companyId
            };

            var password = GeneratePasswordDefault(collaboratorInputModel);

            var role = collaboratorInputModel.IsManager ? RoleEnum.Manager.ToString() : RoleEnum.Member.ToString();

            await _userService.RegisterCollaboratorAsync(user, password, role);

            return new CollaboratorViewModel()
            {
                CPF = user.CPF,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Name = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = role
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

        private string CreateUsername(string name, string document)
        {
            var unicodeWhiteSpace = "\u0020";

            var firtWhiteSpace = name.IndexOf(unicodeWhiteSpace) > 0 ? name.IndexOf(unicodeWhiteSpace) : name.Length;

            var firstName = name.Trim().Substring(0, firtWhiteSpace);

            var firstDigitDocument = document.Substring(0, 3);

            var username = $"{firstName}_{firstDigitDocument}";

            return username;
        }

        private string GeneratePasswordDefault(CollaboratorInputModel collaboratorInputModel)
        {
            var userName = collaboratorInputModel.Name;

            var cpf = collaboratorInputModel.CPF;

            var password = $"{userName[0].ToString().ToUpper()}{userName.Substring(1, 2).ToLower()}@{cpf.Substring(0, 3)}";

            return password;
        }

        private async Task<ApplicationUser> FindManagerAsync(IEnumerable<Claim> claims)
        {
            var emailManager = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            if (emailManager == null) throw new Exception("Erro ao procurar usuário");

            var manager = await _userService.FindUserByEmailAsync(emailManager);

            return manager;
        }

        private async Task<Guid> CreateAddressAsync(AddressInputModel addressInputModel)
        {
            var address = new Address()
            {
                AddressId = Guid.NewGuid(),
                CEP = addressInputModel.CEP,
                City = addressInputModel.City,
                Country = addressInputModel.Country,
                District = addressInputModel.District,
                Number = addressInputModel.Number,
                Reference = string.IsNullOrEmpty(addressInputModel.Reference) ? null : addressInputModel.Reference,
                State = addressInputModel.State,
                Street = addressInputModel.Street
            };

            var addressId = await _userService.RegisterAddressAsync(address);

            return addressId;
        }

        public async Task<List<CollaboratorViewModel>> GetCollaboradorAsync(IEnumerable<Claim> claims)
        {
            var manager = await FindManagerAsync(claims);

            if (manager == null) throw new Exception("Erro ao procurar manager");

            var usersByCompany = await _userService.GetUserByCompanyIdAsync(manager.CompanyId);

            return usersByCompany.Select(user => new CollaboratorViewModel()
            {
                BirthDate = user.BirthDate,
                CPF = user.CPF,
                Email = user.Email,
                Name = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Role = GetUserRole(user).Result
            }).ToList();
        }

        private async Task<string> GetUserRole(ApplicationUser user)
        {
            var roles = await _userService.GetRoleAsync(user);

            return roles[0];
        }
    }
}
