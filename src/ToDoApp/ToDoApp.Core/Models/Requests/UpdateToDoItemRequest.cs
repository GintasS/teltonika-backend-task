namespace ToDoApp.Core.Models.Requests
{
    public class UpdateToDoItemRequest : ToDoItem
    {
        public int ListId { get; set; }
        public int Id { get; set; }
    }
}