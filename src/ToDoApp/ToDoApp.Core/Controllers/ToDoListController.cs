using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        private readonly TodoAppContext _context;

        public ToDoListController(IToDoListService toDoListService, TodoAppContext context)
        {
            _toDoListService = toDoListService;
            _context = context;
        }

        [Route("/todo-lists")]
        [HttpPost]
        public IActionResult CreateEmptyTodoList(CreateToDoListRequestModel createRequestModel)
        {
            var response = _toDoListService.CreateEmptyTodoList(createRequestModel);

            return Ok(response);
        }
    }
}
