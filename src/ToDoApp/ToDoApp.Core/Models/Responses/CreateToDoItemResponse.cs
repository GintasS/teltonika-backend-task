namespace ToDoApp.Core.Models.Responses
{
    public class CreateToDoItemResponse : ToDoItem
    {
        public int Id { get; set; }
        public int ListId { get; set; }
    }
}