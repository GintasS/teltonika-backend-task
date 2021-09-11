using System.Collections.Generic;

namespace ToDoApp.Database.Entities
{
    public class ToDoListEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ToDoItemEntity> ToDoItemEntities { get; set; }
    }
}