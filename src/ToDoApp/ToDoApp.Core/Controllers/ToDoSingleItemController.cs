using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Database;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly TodoAppContext _context;

        public ToDoController(ILogger<ToDoController> logger, TodoAppContext context)
        {
            _logger = logger;
            _context = context;
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
