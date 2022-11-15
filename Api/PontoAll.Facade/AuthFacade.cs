using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
using PontoAll.Models.Token;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IOptions<TokenSettings> _tokenSettings;

        public AuthFacade(IAuthService authService, IUserService userService, IOptions<TokenSettings> tokenSettings)
        {
            _authService = authService;
            _userService = userService;
            _tokenSettings = tokenSettings;
        }

        private string GenerateToken(ApplicationUser user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Value.Secret);

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles[0])
                }),
                Issuer = _tokenSettings.Value.Issuer,
                Audience = _tokenSettings.Value.Audience,
                Expires = DateTime.UtcNow.AddHours(_tokenSettings.Value.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescripter));
        }

        public async Task<string> Login(LoginInputModel loginInputModel)
        {
            var user = await _userService.FindUserByEmailAsync(loginInputModel.Email);

            if (user == null) ExceptionLogin();

            var signInResult = await _authService.SignInAsync(user, loginInputModel.Password);

            if (!signInResult.Succeeded) ExceptionLogin();

            var roles = await _userService.GetRoleAsync(user);

            return GenerateToken(user, roles);
        }

        private void ExceptionLogin() 
        {
            throw new Exception("Email ou Senha incorreto");
        }
    }
}
