using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Helpers;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoItemService _toDoItemService;

        public ToDoListsController(IToDoListService toDoListService, IToDoItemService toDoItemService)
        {
            _toDoListService = toDoListService;
            _toDoItemService = toDoItemService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateEmptyTodoList(CreateToDoListRequest createRequestModel)
        {
            var response = _toDoListService.CreateEmptyTodoList(createRequestModel);
            return Ok(response);
        }

        [Route("/{listId}/items")]
        [Authorize]
        [HttpPost]
        public IActionResult CreateToDoTodoItem(int listId, CreateToDoItemRequest createRequestModel)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound("List was not found.");
            }

            createRequestModel.ListId = listId;

            var response = _toDoItemService.CreateToDoItem(createRequestModel);
            return Ok(response);
        }

        [Route("/{listId}/items")]
        [Authorize]
        [HttpGet]
        public IActionResult ReadAllToDoItemsForList(int listId)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound("List was not found.");
            }

            var response = _toDoItemService.ReadAllToDoItems(listId);
            return Ok(response);
        }

        [Route("/{listId}/items/{itemId}")]
        [Authorize]
        [HttpPatch]
        public IActionResult UpdateToDoTodoItem(int listId, int itemId, UpdateToDoItemRequest updateRequestModel)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound("List was not found.");
            }

            var todoItemExists = _toDoItemService.FindToDoItem(itemId);

            if (todoItemExists == null)
            {
                return NotFound("List Item was not found.");
            }

            updateRequestModel.ListId = listId;
            updateRequestModel.Id = itemId;

            var response = _toDoItemService.UpdateToDoItem(updateRequestModel);
            return Ok(response);
        }

        [Route("/{listId}/items/{itemId}")]
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteToDoTodoItem(int listId, int itemId)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound("List was not found.");
            }

            var todoItem = _toDoItemService.FindToDoItem(itemId);
            if (todoItem == null)
            {
                return NotFound("List Item was not found.");
            }

            var response = _toDoItemService.DeleteToDoItem(todoItem);
            return Ok(response);
        }
    }
}
