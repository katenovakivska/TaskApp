namespace Application.Commands.SharedTaskLists
{
    public class DeleteSharedTaskListCommand
    {
        public Guid ListId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid SharedUserId { get; set; }
    }
}
