using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.Models
{
    public class EmailMessage
    {
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
