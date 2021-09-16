using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using Constants = ToDoApp.Core.Configuration.Constants;

namespace ToDoApp.Core.Controllers
{
    // TODO:
    // 1. Unit tests (if you're going to write them, use Fluent Assertions, Mocks, GWT structure)   +
    // 2. Check all requirements in PDF.                                                            +
    // 3. Run Resharper.                                                                            +
    // 5. Try to have all configuration set in appsettings.json                                     +
    // 6. Apply all attributes for DB Migrations.                                                   +
    // 7. In controllers, add Status code documentation.                                            +
    // 8. Clean up Startup.cs                                                                       +
    // 9. Add comments where needed.                                                                +
    // 10. Remove email credentials from appsettings.json .                                         +
    // 11. Make endpoints to adhere to Restful standards.                                           +
    // 12. Update readme.                                                                           +
    // 13. Use either SingleOrDefault or FirstOrDefault, but not both.                              +
    // 14. Now every time you launch a program, it will recreate all the data in DB.                +
    //     Can this cause errors for us?
    // 15. Run all possible scenarios to catch bugs manually.
    // 16. Remove Unused NuGet packages.                                                            +
    // 17. Make sure that you use "ToDo" format everywhere.
    // 18. Check naming everywhere.
    // 19. Create users with hashed passwords and check the hashes instead of passwords.
    // 19. Add constants file.                                                                      +
    // 20. Validate that attribute constraints actually work.
    // 21. Mappings from entity to model and so on.
    // 22. Consider using async/ await logic.
    // 23. Can you use a better hashing algorithm for Jwt.
    // 24. Add proper email template.
    // 25. Check authorize lock on Swagger documentation. Is this working correctly?
    // 26. Can you combine several endpoints under one controller, at least to use the same path?
    // 27. Check Validation for endpoints.
    // 28. Check if HTTP Methods are implemented correctly.
    // 29. Add proper data to DB Initializer (hashed passwords, proper emails).

    [ApiController]
    [Route("users")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IToDoItemService _toDoItemService;
        private readonly IToDoListService _toDoListService;

        public AdminController(IUserService userService, IToDoItemService toDoItemService, IToDoListService toDoListService)
        {
            _userService = userService;
            _toDoItemService = toDoItemService;
            _toDoListService = toDoListService;
        }

        [AuthorizeAdmin]
        [ProducesResponseType(typeof(IEnumerable<ToDoItem>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [Route("{userId:int}/lists/{listId:int}/items")]
        [HttpGet]
        public IActionResult ReadAllToDoItemsForSpecificUser(int userId, int listId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(Constants.ErrorMessages.UserWithIdDoesNotExist);
            }

            var isCorrectListId = _toDoListService.ToDoListExists(listId);
            if (isCorrectListId == false)
            {
                return NotFound(Constants.ErrorMessages.ListWithIdDoesNotExist);
            }

            var isCorrectUser = _userService.UserHasSpecificList(userId, listId);
            if (isCorrectUser == false)
            {
                return Forbid(Constants.ErrorMessages.UserDoesNotOwnSpecificList);
            }

            var toDoItems = _toDoItemService.ReadAllToDoItems(listId);
            return Ok(toDoItems);
        }

        [AuthorizeAdmin]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [Route("{userId:int}/lists/{listId:int}/items/{itemId:int}")]
        [HttpDelete]
        public IActionResult DeleteTodoItemForSpecificUser(int userId, int listId, int itemId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(Constants.ErrorMessages.UserWithIdDoesNotExist);
            }

            var isCorrectListId = _toDoListService.ToDoListExists(listId);
            if (isCorrectListId == false)
            {
                return NotFound(Constants.ErrorMessages.ListWithIdDoesNotExist);
            }

            var isCorrectUser = _userService.UserHasSpecificList(userId, listId);
            if (isCorrectUser == false)
            {
                return Forbid(Constants.ErrorMessages.UserDoesNotOwnSpecificList);
            }

            var todoItem = _toDoItemService.FindToDoItem(itemId);
            if (todoItem == null)
            {
                return NotFound(Constants.ErrorMessages.ToDoItemWithItemIdDoesNotExist);
            }

            var isSuccess = _toDoItemService.DeleteToDoItem(todoItem);
            return Ok(isSuccess);
        }
    }
}
