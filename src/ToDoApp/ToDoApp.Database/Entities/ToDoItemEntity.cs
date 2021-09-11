namespace ToDoApp.Database.Entities
{
    public class ToDoItemEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public virtual ToDoListEntity ToDoListEntity { get; set; }
    }
}
