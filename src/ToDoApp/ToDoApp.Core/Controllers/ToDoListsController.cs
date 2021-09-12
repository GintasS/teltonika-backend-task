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

        [Route("/{listId:int}/items")]
        [AuthorizeUser]
        [HttpPost]
        public IActionResult CreateToDoItem(int listId, CreateToDoItemRequest createRequestModel)
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

        [Route("/{listId:int}/items")]
        [AuthorizeUser]
        [HttpGet]
        public IActionResult ReadAllToDoItems(int listId)
        {
            var toDoListExists = _toDoListService.ToDoListExists(listId);
            if (toDoListExists == false)
            {
                return NotFound("List was not found.");
            }

            var response = _toDoItemService.ReadAllToDoItems(listId);
            return Ok(response);
        }

        [Route("/{listId:int}/items/{itemId:int}")]
        [AuthorizeUser]
        [HttpPatch]
        public IActionResult UpdateToDoItem(int listId, int itemId, UpdateToDoItemRequest updateRequestModel)
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

        [Route("/{listId:int}/items/{itemId:int}")]
        [AuthorizeUser]
        [HttpDelete]
        public IActionResult DeleteToDoItem(int listId, int itemId)
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
