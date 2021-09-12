using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database.Enums;

namespace ToDoApp.Core.Controllers
{
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IPasswordRecoveryService _passwordRecoveryService;

        public PasswordRecoveryController(IUserService userService, IEmailService emailService, IPasswordRecoveryService passwordRecoveryService)
        {
            _userService = userService;
            _emailService = emailService;
            _passwordRecoveryService = passwordRecoveryService;
        }


        [HttpPut("password-recovery/users/{userId}/recovery-link")]
        public IActionResult SendPasswordRecoveryLink(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User with the provided UserId was not found.");
            }

            _passwordRecoveryService.SetUserPasswordRecoveryStatus(user.Id, PasswordRecoveryStatus.Requested);
            _emailService.SendPasswordRecoveryEmail(user);

            return Ok();
        }

        [HttpPut("password-recovery/users/{userId}/password")]
        public IActionResult ChangePassword(int userId, PasswordRecoveryRequest model)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User with the provided UserId was not found.");
            }

            var recoveryStatus = _passwordRecoveryService.GetUserPasswordRecoveryStatus(userId);
            if (recoveryStatus != PasswordRecoveryStatus.Requested)
            {
                return BadRequest("Password recovery was not requested, please request it first.");
            }

            _passwordRecoveryService.SetUserPasswordRecoveryStatus(userId, PasswordRecoveryStatus.Recovered);
            _passwordRecoveryService.ChangePassword(userId, model);

            return Ok();
        }

    }
}
