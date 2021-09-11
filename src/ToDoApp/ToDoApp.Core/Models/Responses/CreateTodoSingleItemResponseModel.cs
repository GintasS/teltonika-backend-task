using System.Collections.Generic;
using Newtonsoft.Json;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Core.Models.Responses
{
    public class CreateTodoSingleItemResponseModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int ListId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<ToDoSingleItemEntity> ToDoSingleItemEntities { get; set; }
    }
}