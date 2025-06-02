namespace Application.Commands.SharedTaskLists
{
    public interface IDeleteSharedTaskListCommandHandler
    {
        Task<bool> HandleAsync(DeleteSharedTaskListCommand command);
    }
}
