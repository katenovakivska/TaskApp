namespace Application.Commands.TaskLists
{
    public interface IDeleteTaskListCommandHandler
    {
        Task<bool> HandleAsync(DeleteTaskListCommand command);
    }
}
