using BankSystem.Handler;
using BankSystem.Model;
using BankSystem.Model.Api;
using BankSystem.Repository.JWT;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankSystem.Service.JWT
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository authrepository;
        private readonly IConfiguration configuration;

        public AuthService(IAuthRepository authrepository, IConfiguration configuration)
        {
            this.authrepository = authrepository;
            this.configuration = configuration;
        }

        public async Task<LoginResponseModel?> AuthenticateAsync(LoginRequestModel model)
        {
            var user= authrepository.GetUserByUserName(model.UserName);
            if(user == null) return null;

            bool isPasswordValid= PasswordHashHandler.VerifyPassword(model.Password, user.Password);
            if(!isPasswordValid) return null;

            var token = GenerateJwtToken(user);
            return new LoginResponseModel
            {
                AccessToken = token,
                usertype = user.UserType.ToString(),
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

