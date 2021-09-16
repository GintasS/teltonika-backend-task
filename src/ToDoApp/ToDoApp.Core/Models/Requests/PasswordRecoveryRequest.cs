using System.ComponentModel.DataAnnotations;
using ToDoApp.Core.Configuration;

namespace ToDoApp.Core.Models.Requests
{
    public class PasswordRecoveryRequest
    {
        [Required]
        [MinLength(Constants.FieldValidaton.MinPasswordLength)]
        public string NewPassword { get; set; }
    }
}
