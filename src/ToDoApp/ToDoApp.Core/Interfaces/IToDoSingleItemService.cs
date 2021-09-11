using System.Collections.Generic;
using ToDoApp.Core.Models;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoService
    {
        public CreateTodoSingleItemResponseModel CreateToDoSingleTodoItem(CreateTodoSingleItemRequestModel createRequestModel);
        public IEnumerable<ToDoSingleItemModel> ReadAllSingleToDoItems(int listId);
        public UpdateTodoSingleItemResponseModel UpdateToDoSingleTodoItem(UpdateTodoSingleItemRequestModel updateRequestModel);
        public DeleteTodoSingleItemResponseModel DeleteToDoSingleTodoItem(int id);
    }
}
