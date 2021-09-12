using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Database.Entities
{
    public class ToDoListEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual ICollection<ToDoItemEntity> ToDoItemEntities { get; set; }
        [Required]
        public virtual UserEntity UserEntity { get; set; }
    }
}