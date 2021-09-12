using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoApp.Core.Models.Requests
{
    public class PasswordRecoveryRequest
    {
        public string NewPassword { get; set; }
    }
}
