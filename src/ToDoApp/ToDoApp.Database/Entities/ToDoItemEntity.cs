using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Database.Entities
{
    public class ToDoItemEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public virtual ToDoListEntity ToDoListEntity { get; set; }
    }
}
