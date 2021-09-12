using System.Linq;
using ToDoApp.Core.Interfaces;
using ToDoApp.Database;

namespace ToDoApp.Core.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly TodoAppContext _context;

        public ToDoListService(TodoAppContext context)
        {
            _context = context;
        }

        public bool ToDoListExists(int listId)
        {
            return _context.ToDoListEntities.FirstOrDefault(x => x.Id == listId) != null;
        }
    }
}
