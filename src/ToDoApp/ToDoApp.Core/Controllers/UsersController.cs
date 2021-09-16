using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Mappings;
using ToDoApp.Core.Models;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(typeof(UpdateToDoItemResponse), 200)]
        [ProducesResponseType(400)]
        [Route("authenticate")]
        [HttpPost]
        public IActionResult AuthenticateUser(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(Constants.ErrorMessages.UsernameOrPasswordIsWrong);
            }

            return Ok(response);
        }

        [AuthorizeUser]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers()
                .Select(x => x.MapToUser());

            return Ok(users);
        }
    }
}
