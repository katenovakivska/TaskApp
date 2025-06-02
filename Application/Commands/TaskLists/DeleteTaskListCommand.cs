namespace Application.Commands.TaskLists
{
    public class DeleteTaskListCommand
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
