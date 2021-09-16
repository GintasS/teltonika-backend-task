using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Mappings;
using ToDoApp.Core.Models;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly SmtpClient _smtpClient;

        public EmailService(IOptionsMonitor<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.CurrentValue;
            _smtpClient = new SmtpClient(_emailSettings.HostUrl)
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.EmailCredentials.Email, _emailSettings.EmailCredentials.Password),
                EnableSsl = _emailSettings.EnableSsl
            };
        }

        public void SendPasswordRecoveryEmail(UserEntity user)
        {
            var emailMessage = user.MapToEmailMessage(_emailSettings.PasswordRecoveryEmailTemplate);

            SendEmail(emailMessage);
        }

        private void SendEmail(EmailMessage message)
        {
            _smtpClient.Send(_emailSettings.EmailCredentials.Email, message.RecipientEmail, message.Subject, message.Body);
        }
    }
}
