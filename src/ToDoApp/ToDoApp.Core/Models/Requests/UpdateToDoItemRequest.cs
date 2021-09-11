using System.Text.Json.Serialization;

namespace ToDoApp.Core.Models.Requests
{
    public class UpdateToDoItemRequest : ToDoItem
    {
        [JsonIgnore]

        public int ListId { get; set; }
        [JsonIgnore]
        public int Id { get; set; }
    }
}