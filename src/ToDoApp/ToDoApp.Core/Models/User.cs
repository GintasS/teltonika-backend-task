using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ToDoApp.Core.Configuration;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        [Required]
        [MinLength(Constants.FieldValidaton.MinPasswordLength)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}