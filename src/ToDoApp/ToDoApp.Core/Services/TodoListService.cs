using System.Linq;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;
using ToDoApp.Database;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly TodoAppContext _context;

        public ToDoListService(TodoAppContext context)
        {
            _context = context;
        }

        public CreateToDoListResponse CreateEmptyTodoList(CreateToDoListRequest requestModel)
        {
            var createdEntity = _context.ToDoListEntities.Add(new ToDoListEntity
            {
                Name = requestModel.Name
            }).Entity;

            _context.SaveChanges();

            return new CreateToDoListResponse
            {
                Id = createdEntity.Id,
                Name = createdEntity.Name
            };
        }

        public bool ToDoListExists(int listId)
        {
            return _context.ToDoListEntities.FirstOrDefault(x => x.Id == listId) != null;
        }
    }
}
