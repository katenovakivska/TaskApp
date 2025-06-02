using Domain.Entities;

namespace Application.Commands.SharedTaskLists
{
    public interface ICreateSharedTaskListCommandHandler
    {
        Task<SharedTaskList?> HandleAsync(CreateSharedTaskListCommand command);
    }
}
