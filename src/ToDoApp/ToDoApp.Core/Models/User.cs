using System.Text.Json.Serialization;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}