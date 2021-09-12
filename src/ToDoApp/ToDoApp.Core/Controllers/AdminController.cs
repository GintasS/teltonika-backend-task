using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [Route("/users/{userId}/lists/{listId}/items")]
        [AuthorizeAdmin]
        [HttpGet]
        public IActionResult ReadAllToDoItemsForSpecificUser(int userId, int listId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return BadRequest("User with provided UserId does not exist.");
            }

            var isCorrectListId = _toDoListService.ToDoListExists(listId);
            if (isCorrectListId == false)
            {
                return BadRequest("List with provided Id does not exist.");
            }

            var isCorrectUser = _userService.UserHasSpecificList(userId, listId);
            if (isCorrectUser == false)
            {
                return BadRequest("User does not own this list.");
            }

            var toDoItems = _toDoItemService.ReadAllToDoItems(listId);
            return Ok(toDoItems);
        }

        [Route("/users/{userId}/lists/{listId}/items/{itemId}")]
        [AuthorizeAdmin]
        [HttpDelete]
        public IActionResult DeleteTodoItemForSpecificUser(int userId, int listId, int itemId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User with provided UserId does not exist.");
            }

            var isCorrectListId = _toDoListService.ToDoListExists(listId);
            if (isCorrectListId == false)
            {
                return NotFound("List with provided Id does not exist.");
            }

            var isCorrectUser = _userService.UserHasSpecificList(userId, listId);
            if (isCorrectUser == false)
            {
                return Forbid("User does not own this list.");
            }

            var todoItem = _toDoItemService.FindToDoItem(itemId);
            if (todoItem == null)
            {
                return NotFound("List Item was not found.");
            }

            var isSucccess = _toDoItemService.DeleteToDoItem(todoItem);
            return Ok(isSucccess);
        }


    }
}
