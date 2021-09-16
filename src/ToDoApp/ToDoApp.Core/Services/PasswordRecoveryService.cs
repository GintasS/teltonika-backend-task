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

        public bool ChangePassword(int userId, PasswordRecoveryRequest model)
        {
            var user = _context.UserEntities.SingleOrDefault(x => x.Id == userId);
            if (user == null)
            {
                return false;
            }

            user.Password = model.NewPassword;
            _context.SaveChanges();

            return true;
        }

        public PasswordRecoveryStatus GetUserPasswordRecoveryStatus(int userId)
        {
            var entity = _context.PasswordRecoveryEntities.SingleOrDefault(x => x.UserEntity.Id == userId);
            return entity?.PasswordRecoveryStatus ?? PasswordRecoveryStatus.None;
        }

        public void SetUserPasswordRecoveryStatus(int userId, PasswordRecoveryStatus recoveryStatus)
        {
            var entity = _context.PasswordRecoveryEntities.SingleOrDefault(x => x.UserEntity.Id == userId);
            if (entity == null)
            {
                return;
            }
            
            entity.PasswordRecoveryStatus = recoveryStatus;
            _context.SaveChanges();
        }
    }
}
