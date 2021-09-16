using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Controllers
{
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IPasswordRecoveryService _passwordRecoveryService;

        public AccountsController(IUserService userService, IEmailService emailService, IPasswordRecoveryService passwordRecoveryService)
        {
            _userService = userService;
            _emailService = emailService;
            _passwordRecoveryService = passwordRecoveryService;
        }

        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [Route("password-recovery/{userId:int}")]
        [HttpPut]
        public IActionResult SendPasswordRecoveryLink(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(Constants.ErrorMessages.UserWithIdDoesNotExist);
            }
            if (user.Role == Role.Admin)
            {
                return Forbid(Constants.ErrorMessages.NoPasswordChangeForAdminRole);
            }

            _passwordRecoveryService.SetUserPasswordRecoveryStatus(user.Id, PasswordRecoveryStatus.Requested);
            _emailService.SendPasswordRecoveryEmail(user);

            return Ok();
        }

        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("password/{userId:int}")]
        [HttpPut]
        public IActionResult ChangePassword(int userId, PasswordRecoveryRequest model)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(Constants.ErrorMessages.UserWithIdDoesNotExist);
            }

            var recoveryStatus = _passwordRecoveryService.GetUserPasswordRecoveryStatus(userId);
            if (recoveryStatus != PasswordRecoveryStatus.Requested)
            {
                return BadRequest(Constants.ErrorMessages.PasswordRecoveryNotInitiated);
            }

            _passwordRecoveryService.SetUserPasswordRecoveryStatus(userId, PasswordRecoveryStatus.None);
            var isPasswordChanged = _passwordRecoveryService.ChangePassword(userId, model);

            return Ok(isPasswordChanged);
        }
    }
}
