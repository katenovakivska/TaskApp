namespace Application.Commands.SharedTaskLists
{
    public class CreateSharedTaskListCommand
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
