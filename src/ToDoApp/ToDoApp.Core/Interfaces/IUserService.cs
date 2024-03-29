﻿using System.Collections.Generic;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public IEnumerable<UserEntity> GetAllUsers();
        public UserEntity GetUserById(int userId);
        public bool AuthenticatedUserHasSpecificList(int listId);
        public bool UserHasSpecificList(int userId, int listId);
    }
}
