namespace Application.Commands.TaskLists
{
    public interface IUpdateTaskListCommandHandler
    {
        Task<bool> HandleAsync(UpdateTaskListCommand command);
    }
}
