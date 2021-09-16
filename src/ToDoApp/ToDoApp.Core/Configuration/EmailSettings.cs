namespace ToDoApp.Core.Configuration
{
    public class EmailSettings
    {
        public string HostUrl { get; set; }
        public EmailCredentials EmailCredentials { get; set; }
        public PasswordRecoveryEmailTemplate PasswordRecoveryEmailTemplate { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }

    public class EmailCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class PasswordRecoveryEmailTemplate
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
