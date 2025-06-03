using Application.Common.Interfaces;

namespace Application.Commands.SharedTaskLists
{
    public class DeleteSharedTaskListCommand: ICommand<bool>
    {
        public Guid ListId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid SharedUserId { get; set; }
    }
}
