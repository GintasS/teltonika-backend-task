using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Requests;
using ToDoApp.Core.Responses;
using ToDoApp.Database;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly TodoAppContext _context;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(TodoAppContext context, IJwtService jwtService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.UserEntities.SingleOrDefault(x =>
                x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                return null;
            }

            var token = _jwtService.GenerateToken(user);

            return new AuthenticateResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
                Email = user.Email
            };
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _context.UserEntities.ToList();
        }

        public UserEntity GetUserById(int userId)
        {
            return _context.UserEntities.SingleOrDefault(x => x.Id == userId);
        }

        public bool AuthenticatedUserHasSpecificList(int listId)
        {
            var user = (UserEntity)_httpContextAccessor.HttpContext.Items["User"];

            return UserHasSpecificList(user.Id, listId);
        }

        public bool UserHasSpecificList(int userId, int listId)
        {
            var list = _context.ToDoListEntities.FirstOrDefault(x => x.Id == listId);

            if (list == null)
            {
                return false;
            }

            return list.UserEntity.Id == userId;
        }
    }
}
