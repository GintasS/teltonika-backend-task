using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
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

        public UserService(TodoAppContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
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
    }
}
