using System.Collections.Generic;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoItemService
    {
        public CreateToDoItemResponse CreateToDoItem(CreateToDoItemRequest createRequestModel);
        public IEnumerable<ReadToDoItemResponse> ReadAllToDoItems(int listId);
        public UpdateToDoItemResponse UpdateToDoItem(UpdateToDoItemRequest updateRequestModel);
        public int DeleteToDoItem(int id);
    }
}
