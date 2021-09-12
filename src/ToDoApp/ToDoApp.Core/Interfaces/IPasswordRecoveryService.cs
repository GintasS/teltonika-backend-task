﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Interfaces
{
    public interface IPasswordRecoveryService
    {
        public PasswordRecoveryStatus GetUserPasswordRecoveryStatus(int userId);
        public void SetUserPasswordRecoveryStatus(int userId, PasswordRecoveryStatus recoveryStatus);
        public void ChangePassword(int userId, PasswordRecoveryRequest model);
    }
}