using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("todolists")]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoItemService _toDoItemService;
        private readonly IUserService _userService;

        public ToDoListsController(IToDoListService toDoListService, IToDoItemService toDoItemService, IUserService userService)
        {
            _toDoListService = toDoListService;
            _toDoItemService = toDoItemService;
            _userService = userService;
        }

        [AuthorizeUser]
        [ProducesResponseType(typeof(CreateToDoItemResponse), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [Route("{listId:int}/items")]
        [HttpPost]
        public IActionResult CreateToDoItem(int listId, CreateToDoItemRequest createRequestModel)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound(Constants.ErrorMessages.ListWithIdDoesNotExist);
            }

            var listBelongsToAuthenticatedUser = _userService.AuthenticatedUserHasSpecificList(listId);
            if (listBelongsToAuthenticatedUser == false)
            {
                return Forbid(Constants.ErrorMessages.UserDoesNotOwnSpecificList);
            }

            createRequestModel.ListId = listId;

            var response = _toDoItemService.CreateToDoItem(createRequestModel);
            return Ok(response);
        }

        [AuthorizeUser]
        [ProducesResponseType(typeof(ReadToDoItemResponse), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [Route("{listId:int}/items")]
        [HttpGet]
        public IActionResult ReadAllToDoItems(int listId)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound(Constants.ErrorMessages.ListWithIdDoesNotExist);
            }

            var listBelongsToAuthenticatedUser = _userService.AuthenticatedUserHasSpecificList(listId);
            if (listBelongsToAuthenticatedUser == false)
            {
                return Forbid(Constants.ErrorMessages.UserDoesNotOwnSpecificList);
            }

            var response = _toDoItemService.ReadAllToDoItems(listId);
            return Ok(response);
        }

        [AuthorizeUser]
        [ProducesResponseType(typeof(UpdateToDoItemResponse), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [Route("{listId:int}/items/{itemId:int}")]
        [HttpPatch]
        public IActionResult UpdateToDoItem(int listId, int itemId, UpdateToDoItemRequest updateRequestModel)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound(Constants.ErrorMessages.ListWithIdDoesNotExist);
            }

            var listBelongsToAuthenticatedUser = _userService.AuthenticatedUserHasSpecificList(listId);
            if (listBelongsToAuthenticatedUser == false)
            {
                return Forbid(Constants.ErrorMessages.UserDoesNotOwnSpecificList);
            }

            var todoItem = _toDoItemService.FindToDoItem(itemId);
            if (todoItem == null)
            {
                return NotFound(Constants.ErrorMessages.ToDoItemWithItemIdDoesNotExist);
            }

            updateRequestModel.ListId = listId;
            updateRequestModel.Id = itemId;

            var response = _toDoItemService.UpdateToDoItem(updateRequestModel);
            return Ok(response);
        }

        [AuthorizeUser]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [Route("{listId:int}/items/{itemId:int}")]
        [HttpDelete]
        public IActionResult DeleteToDoItem(int listId, int itemId)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound(Constants.ErrorMessages.ListWithIdDoesNotExist);
            }

            var listBelongsToAuthenticatedUser = _userService.AuthenticatedUserHasSpecificList(listId);
            if (listBelongsToAuthenticatedUser == false)
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
