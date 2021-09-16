using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDoApp.Core.Configuration;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Helpers
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserEntity) context.HttpContext.Items[Constants.Jwt.User];

            if (user == null)
            {
                context.Result = new JsonResult(new {message = Constants.ErrorMessages.Unauthorized })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            else if (user.Role == Role.User)
            {
                context.Result = new JsonResult(new { message = Constants.ErrorMessages.Forbidden })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}
