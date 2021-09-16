using System;
using System.Text;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;
using ToDoApp.Database.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ToDoApp.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptionsMonitor<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.CurrentValue;
        }

        public string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim(_jwtSettings.TokenGeneration.ClaimType, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.TokenGeneration.DaysUntilExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), _jwtSettings.TokenGeneration.HashingAlgorithm)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
