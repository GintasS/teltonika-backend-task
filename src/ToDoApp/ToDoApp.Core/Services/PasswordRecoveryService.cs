using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Services
{
    public class PasswordRecoveryService : IPasswordRecoveryService
    {
        private readonly TodoAppContext _context;
        private readonly IUserService _userService;

        public PasswordRecoveryService(TodoAppContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public void ChangePassword(int userId, PasswordRecoveryRequest model)
        {
            var user = _context.UserEntities.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return;
            }

            user.Password = model.NewPassword;

            _context.SaveChanges();
        }

        public PasswordRecoveryStatus GetUserPasswordRecoveryStatus(int userId)
        {
            var entity = _context.PasswordRecoveryEntities.FirstOrDefault(x => x.UserEntity.Id == userId);

            if (entity == null)
            {
                return PasswordRecoveryStatus.None;
            }

            return entity.PasswordRecoveryStatus;
        }

        public void SetUserPasswordRecoveryStatus(int userId, PasswordRecoveryStatus recoveryStatus)
        {
            var entity = _context.PasswordRecoveryEntities.FirstOrDefault(x => x.UserEntity.Id == userId);

            if (entity == null)
            {
                return;
            }

            entity.PasswordRecoveryStatus = recoveryStatus; 

            _context.SaveChanges();
        }


    }
}
