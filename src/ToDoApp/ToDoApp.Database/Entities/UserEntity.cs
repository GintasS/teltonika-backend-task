using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Asn1.X509;

namespace ToDoApp.Database.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
