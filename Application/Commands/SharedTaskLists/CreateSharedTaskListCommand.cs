using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Commands.SharedTaskLists
{
    public class CreateSharedTaskListCommand: ICommand<(SharedTaskList? access, bool isListFound, bool isAccessCreated)>
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        public Guid SharedUserId { get; set; }
    }
}
