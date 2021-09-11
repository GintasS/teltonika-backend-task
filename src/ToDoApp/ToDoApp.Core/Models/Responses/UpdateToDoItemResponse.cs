namespace ToDoApp.Core.Models.Responses
{
    public class UpdateToDoItemResponse : ToDoItem
    {
        public int ListId { get; set; }
        public int Id { get; set; }
    }
}