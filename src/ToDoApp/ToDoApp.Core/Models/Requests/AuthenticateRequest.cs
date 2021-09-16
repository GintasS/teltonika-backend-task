using System.ComponentModel.DataAnnotations;
using ToDoApp.Core.Configuration;

namespace ToDoApp.Core.Models.Requests
{
    public class AuthenticateRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(Constants.FieldValidaton.MinPasswordLength)]
        public string Password { get; set; }
    }
}