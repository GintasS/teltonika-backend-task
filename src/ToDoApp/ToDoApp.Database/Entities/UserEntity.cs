using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Org.BouncyCastle.Asn1.X509;
using ToDoApp.Database.Enums;

namespace ToDoApp.Database.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(12)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
