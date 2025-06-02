namespace Application.Commands.TaskLists
{
    public class CreateTaskItemCommand
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
