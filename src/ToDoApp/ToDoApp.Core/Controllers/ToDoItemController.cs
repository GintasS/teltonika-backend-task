using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }


        [Route("/todo-list-items")]
        [HttpPost]
        public IActionResult CreateToDoTodoItem(CreateToDoItemRequest createRequestModel)
        {
            var response = _toDoItemService.CreateToDoItem(createRequestModel);

            return Ok(response);
        }

        [Route("/todo-list-items")]
        [HttpGet]
        public IActionResult ReadAllToDoItems(int listId)
        {
            var response = _toDoItemService.ReadAllToDoItems(listId);
            return Ok(response);
        }

        [Route("/todo-list-items")]
        [HttpPut]
        public IActionResult UpdateToDoTodoItem(UpdateToDoItemRequest updateRequestModel)
        {
            var response = _toDoItemService.UpdateToDoItem(updateRequestModel);
            return Ok(response);
        }

        [Route("/todo-list-items")]
        [HttpDelete]
        public IActionResult DeleteToDoTodoItem(int id)
        {
            var response = _toDoItemService.DeleteToDoItem(id);
            return Ok(response);
        }
    }
}
