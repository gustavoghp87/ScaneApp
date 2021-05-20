using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WS_ScaneApp.Models;
using WS_ScaneApp.Models.Common;
using WS_ScaneApp.Models.ProjectRequests;
using WS_ScaneApp.Models.ProjectResponses;
using WS_ScaneApp.Tools;

namespace WS_ScaneApp.Services
{
    public class UserService : IUserService
    {
        private readonly ProjectAppSettings _appSettings;

        public UserService(IOptions<ProjectAppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new();
            using (var context = new ScaneAppContext())
            {
                string encryptedPsw = Encrypt.GetSHA256(model.Password);
                var user = context.Users.Where(x => x.Email == model.Email && x.Password == encryptedPsw).FirstOrDefault();
                if (user == null) return null;
                userResponse.Email = user.Email;
                userResponse.Token = GenerateToken(user);
            }
            return userResponse;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretString);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
