using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Core.Configuration
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public DateTime ExpirationTime { get; set; } = 
    }
}
