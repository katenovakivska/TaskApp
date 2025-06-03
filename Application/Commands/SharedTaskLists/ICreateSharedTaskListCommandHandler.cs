using Domain.Entities;

namespace Application.Commands.SharedTaskLists
{
    public interface ICreateSharedTaskListCommandHandler
    {
        Task<(SharedTaskList? access, bool isListFound, bool isAccessCreated)> HandleAsync(CreateSharedTaskListCommand command);
    }
}
