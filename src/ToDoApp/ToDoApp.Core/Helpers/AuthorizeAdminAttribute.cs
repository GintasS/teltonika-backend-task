using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Helpers
{
    public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter
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
            else if (user.Role == Role.Admin)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}
