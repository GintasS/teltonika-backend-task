using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(UserEntity user);
    }
}
