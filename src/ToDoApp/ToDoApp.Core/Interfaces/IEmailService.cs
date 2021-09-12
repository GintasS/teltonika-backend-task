using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(EmailMessage emailMessage);
        public Task SendPasswordRecoveryEmail(UserEntity user);
    }
}
