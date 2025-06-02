using Domain.Entities;

namespace Application.Commands.TaskLists
{
    public interface ICreateTaskListCommandHandler
    {
        Task<TaskList?> HandleAsync(CreateTaskListCommand command);
    }
}
