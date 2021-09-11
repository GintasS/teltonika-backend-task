using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Entities
{
    public class ToDoSingleItemEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public virtual TodoListEntity TodoListEntity { get; set; }
    }
}
