using System.Collections.Generic;
using System.Linq;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Mappings;
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
            var existingToDoList = _context.ToDoListEntities.SingleOrDefault(x => x.Id == createRequest.ListId);
            if (existingToDoList == null)
            {
                return null;
            }

            var entityToAdd = createRequest.MapToToDoItemEntity(existingToDoList);
            var createdDbEntity = _context.ToDoItemEntities.Add(entityToAdd).Entity;
            _context.SaveChanges();

            return createdDbEntity.MapToCreateToDoItemResponse();
        }

        public IEnumerable<ReadToDoItemResponse> ReadAllToDoItems(int listId)
        {
            var toDoItems = _context.ToDoItemEntities.Where(x => x.ToDoListEntity.Id == listId)
                .Select(x => x.MapToReadToDoItemResponse())
                .ToList();

            return toDoItems;
        }

        public UpdateToDoItemResponse UpdateToDoItem(UpdateToDoItemRequest updateRequestModel)
        {
            var existingToDoItem = _context.ToDoItemEntities.SingleOrDefault(x => x.ToDoListEntity.Id == updateRequestModel.ListId && x.Id == updateRequestModel.Id);
            if (existingToDoItem == null)
            {
                return null;
            }

            existingToDoItem.Name = updateRequestModel.Name;
            existingToDoItem.IsDone = updateRequestModel.IsDone;
            _context.SaveChanges();

            return existingToDoItem.MapToUpdateToDoItemResponse();
        }

        public bool DeleteToDoItem(ToDoItemEntity toDoItem)
        {
            _context.ToDoItemEntities.Remove(toDoItem);
            var deletionStatus =_context.SaveChanges();

            return deletionStatus == 1;
        }

        public ToDoItemEntity FindToDoItem(int itemId)
        {
            return _context.ToDoItemEntities.Find(itemId);
        }
    }
}
