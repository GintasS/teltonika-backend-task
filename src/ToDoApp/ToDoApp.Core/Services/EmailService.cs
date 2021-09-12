using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptionsMonitor<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.CurrentValue;
        }

        public void SendPasswordRecoveryEmail(UserEntity user)
        {
            var emailMessage = new EmailMessage
            {
                RecipientEmail = user.Email,
                Subject = "Password Recovery - ToDo App",
                Body = @$"Password recovery link: https://localhost:44397/password-recovery/users/{user.Id}/password"
            };

            SendEmail(emailMessage);
        }

        private void SendEmail(EmailMessage emailMessage)
        {
            var smtpClient = new SmtpClient(_emailSettings.HostUrl)
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.EmailCredentials.Email, _emailSettings.EmailCredentials.Password),
                EnableSsl = _emailSettings.EnableSsl
            };

            smtpClient.Send(_emailSettings.EmailCredentials.Email, emailMessage.RecipientEmail, emailMessage.Subject, emailMessage.Body);
        }
    }
}
