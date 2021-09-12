using System.ComponentModel.DataAnnotations;
using ToDoApp.Database.Enums;

namespace ToDoApp.Database.Entities
{
    public class PasswordRecoveryEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public virtual UserEntity UserEntity { get; set; }
        public PasswordRecoveryStatus PasswordRecoveryStatus { get; set; }
    }
}