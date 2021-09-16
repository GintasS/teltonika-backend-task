using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;

        public JwtMiddleware(RequestDelegate next, IOptionsMonitor<JwtSettings> jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings.CurrentValue;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers[Constants.Jwt.Authorization].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                AttachUserToContext(context, userService, token);
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Set ClockSkew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later).
                    ClockSkew = TimeSpan.Zero

                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken) validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == Constants.Jwt.UserId).Value);

                // attach user to context on successful jwt validation
                context.Items[Constants.Jwt.User] = userService.GetUserById(userId);
            }
            catch
            {
                // Do nothing if jwt validation fails.
                // User is not attached to context so request won't have access to secure routes.
            }
        }
    }
}
