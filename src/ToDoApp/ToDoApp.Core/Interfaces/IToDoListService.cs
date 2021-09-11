using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoListService
    {
        public CreateToDoListResponse CreateEmptyTodoList(CreateToDoListRequest requestModel);
        public bool ToDoListExists(int listId);
    }
}
