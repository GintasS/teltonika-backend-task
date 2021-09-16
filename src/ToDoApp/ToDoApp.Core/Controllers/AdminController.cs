using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using Constants = ToDoApp.Core.Configuration.Constants;

namespace ToDoApp.Core.Controllers
{
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
