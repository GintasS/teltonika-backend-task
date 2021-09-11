using System.Collections.Generic;

namespace ToDoApp.Domain.Entities
{
    public class TodoListEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ToDoSingleItemEntity> ToDoSingleItemEntities { get; set; }
    }
}