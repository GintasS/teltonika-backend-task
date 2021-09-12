namespace ToDoApp.Core.Models
{
    public abstract class ToDoItem
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}