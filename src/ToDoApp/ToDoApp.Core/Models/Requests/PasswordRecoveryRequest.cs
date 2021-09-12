using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.Models.Requests
{
    public class PasswordRecoveryRequest
    {
        [Required]
        [MinLength(12)]
        public string NewPassword { get; set; }
    }
}
