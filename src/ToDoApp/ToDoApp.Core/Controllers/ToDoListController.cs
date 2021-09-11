using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [Route("/todo-lists")]
        [HttpPost]
        public IActionResult CreateEmptyTodoList(CreateToDoListRequest createRequestModel)
        {
            var response = _toDoListService.CreateEmptyTodoList(createRequestModel);
            return Ok(response);
        }
    }
}
