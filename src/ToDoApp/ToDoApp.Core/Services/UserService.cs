using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class UserService : IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
