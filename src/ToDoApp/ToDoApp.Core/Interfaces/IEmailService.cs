using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IEmailService
    {
        public void SendPasswordRecoveryEmail(UserEntity user);
    }
}
