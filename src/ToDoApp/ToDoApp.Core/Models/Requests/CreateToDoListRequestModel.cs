using System.Collections.Generic;
using System.Text.Json.Serialization;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Core.Models.Requests
{
    public class CreateToDoListRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<ToDoSingleItemEntity> ToDoSingleItemEntities { get; set; }
    }
}
