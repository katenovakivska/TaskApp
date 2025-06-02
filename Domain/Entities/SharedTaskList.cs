using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class SharedTaskList
    {
        public Guid Id { get; set; }
        public Guid TaskListId { get; set; }
        public Guid SharedWithUserId { get; set; }

        [JsonIgnore]
        public TaskList TaskList { get; set; } = null!;
    }
}
