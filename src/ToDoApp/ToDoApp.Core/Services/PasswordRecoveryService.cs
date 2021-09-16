using System.Linq;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Services
{
    public class PasswordRecoveryService : IPasswordRecoveryService
    {
        private readonly TodoAppContext _context;

        public PasswordRecoveryService(TodoAppContext context)
        {
            _context = context;
        }

        public void ChangePassword(int userId, PasswordRecoveryRequest model)
        {
            var user = _context.UserEntities.FirstOrDefault(x => x.Id == userId);

            user.Password = model.NewPassword;

            _context.SaveChanges();
        }

        public PasswordRecoveryStatus GetUserPasswordRecoveryStatus(int userId)
        {
            var entity = _context.PasswordRecoveryEntities.FirstOrDefault(x => x.UserEntity.Id == userId);

            return entity?.PasswordRecoveryStatus ?? PasswordRecoveryStatus.None;
        }

        public void SetUserPasswordRecoveryStatus(int userId, PasswordRecoveryStatus recoveryStatus)
        {
            var entity = _context.PasswordRecoveryEntities.FirstOrDefault(x => x.UserEntity.Id == userId);

            entity.PasswordRecoveryStatus = recoveryStatus; 

            _context.SaveChanges();
        }
    }
}
