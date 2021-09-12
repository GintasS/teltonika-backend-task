using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoListService
    {
        public bool ToDoListExists(int listId);
    }
}
