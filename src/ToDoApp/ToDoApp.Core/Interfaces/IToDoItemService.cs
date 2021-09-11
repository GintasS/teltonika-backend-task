using System.Collections.Generic;
using ToDoApp.Core.Models;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoItemService
    {
        public CreateToDoItemResponse CreateToDoItem(CreateToDoItemRequest createRequestModel);
        public IEnumerable<ReadToDoItemResponse> ReadAllToDoItems(int listId);
        public UpdateToDoItemResponse UpdateToDoItem(UpdateToDoItemRequest updateRequestModel);
        public bool DeleteToDoItem(ToDoItemEntity todoItem);
        public ToDoItemEntity FindToDoItem(int itemId);
    }
}
