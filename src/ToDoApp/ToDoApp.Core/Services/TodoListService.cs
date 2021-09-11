using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;
using ToDoApp.Database;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Core.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly TodoAppContext _context;

        public ToDoListService(TodoAppContext context)
        {
            _context = context;
        }

        public CreateToDoListResponseModel CreateEmptyTodoList(CreateToDoListRequestModel requestModel)
        {
            var createdEntity = _context.TodoListEntities.Add(new TodoListEntity()
            {
                Name = requestModel.Name
            }).Entity;

            _context.SaveChanges();

            return new CreateToDoListResponseModel
            {
                Id = createdEntity.Id,
                Name = createdEntity.Name
            };

        }
    }
}
