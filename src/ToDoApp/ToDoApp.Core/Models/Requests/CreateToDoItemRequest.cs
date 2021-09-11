using System.Text.Json.Serialization;

namespace ToDoApp.Core.Models.Requests
{
    public class CreateToDoItemRequest : ToDoItem
    {
        [JsonIgnore]
        public int ListId { get; set; }
    }
}