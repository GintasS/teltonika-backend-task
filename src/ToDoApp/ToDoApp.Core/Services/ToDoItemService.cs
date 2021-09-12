using System.Collections.Generic;
using System.Linq;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;
using ToDoApp.Database;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly TodoAppContext _context;

        public ToDoItemService(TodoAppContext context)
        {
            _context = context;
        }

        public CreateToDoItemResponse CreateToDoItem(CreateToDoItemRequest createRequest)
        {
            var existingToDoList = _context.ToDoListEntities.FirstOrDefault(x => x.Id == createRequest.ListId);

            if (existingToDoList == null)
            {
                throw new KeyNotFoundException("ToDo List id is not found.");
            }

            var createdItem = _context.ToDoItemEntities.Add(new ToDoItemEntity
            {
                Name = createRequest.Name,
                IsDone = createRequest.IsDone,
                ToDoListEntity = existingToDoList
            }).Entity;

            _context.SaveChanges();

            return new CreateToDoItemResponse
            {
                Id = createdItem.Id,
                ListId = createdItem.ToDoListEntity.Id,
                Name = createdItem.Name,
                IsDone = createdItem.IsDone
            };
        }

        public IEnumerable<ReadToDoItemResponse> ReadAllToDoItems(int listId)
        {
            var toDoItems = _context.ToDoItemEntities.Where(x => x.ToDoListEntity.Id == listId)
                .Select(x => new ReadToDoItemResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDone = x.IsDone
                })
                .ToList();

            return toDoItems;
        }

        public UpdateToDoItemResponse UpdateToDoItem(UpdateToDoItemRequest updateRequestModel)
        {
            var existingToDoItem = _context.ToDoItemEntities.FirstOrDefault(x => x.ToDoListEntity.Id == updateRequestModel.ListId && x.Id == updateRequestModel.Id);

            if (existingToDoItem == null)
            {
                return new UpdateToDoItemResponse();
            }

            existingToDoItem.Name = updateRequestModel.Name;
            existingToDoItem.IsDone = updateRequestModel.IsDone;

            _context.SaveChanges();

            return new UpdateToDoItemResponse
            {
                ListId = existingToDoItem.ToDoListEntity.Id,
                Id = existingToDoItem.Id,
                Name = existingToDoItem.Name,
                IsDone = existingToDoItem.IsDone
            };
        }

        public bool DeleteToDoItem(ToDoItemEntity toDoItem)
        {
            _context.ToDoItemEntities.Remove(toDoItem);
            _context.SaveChanges();

            return true;
        }

        public ToDoItemEntity FindToDoItem(int itemId)
        {
            return _context.ToDoItemEntities.Find(itemId);
        }
    }
}
