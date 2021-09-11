using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(UserEntity user);
    }
}
