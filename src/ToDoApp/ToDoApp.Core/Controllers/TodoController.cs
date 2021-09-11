using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Database;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoAppContenxt _context;

        public TodoController(ILogger<TodoController> logger, TodoAppContenxt context)
        {
            _logger = logger;
            _context = context;
            DataSeeder.InsertTodoData(_context);
        }

        [Route("/helloWorld")]
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<ToDoSingleItemEntity> Get()
        {
            var t = _context.ToDoSingleItemEntities.ToList();
            return t;
        }




    }
}
