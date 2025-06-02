namespace Domain.Entities
{
    public class TaskList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Guid OwnerId { get; set; }

        public List<TaskItem> Tasks { get; set; } = new();
        public List<SharedTaskList> SharedWithUsers { get; set; } = new();
    }
}
