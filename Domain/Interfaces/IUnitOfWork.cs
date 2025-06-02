namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ISharedTaskListRepository SharedTaskLists { get; }
        ITaskItemRepository TaskItems { get; }
        ITaskListRepository TaskLists { get; }

        Task SaveChangesAsync();
    }
}
