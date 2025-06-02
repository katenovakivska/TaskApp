using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public Guid TaskListId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        [JsonIgnore]
        public TaskList? TaskList { get; set; } = null!;
    }
}
