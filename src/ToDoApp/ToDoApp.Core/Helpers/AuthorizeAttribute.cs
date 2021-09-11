using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDoApp.Core.Models;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Helpers
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserEntity) context.HttpContext.Items["User"];

            if (user == null)
            {
                context.Result = new JsonResult(new {message = "Unauthorized"})
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
