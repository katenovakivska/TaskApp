using Application.Common.Interfaces;

namespace Application.Commands.TaskLists
{
    public class DeleteTaskListCommand: ICommand<bool>
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
