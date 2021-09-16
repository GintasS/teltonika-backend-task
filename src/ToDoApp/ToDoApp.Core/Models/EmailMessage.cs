using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.Models
{
    [Serializable]
    public class EmailMessage
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
