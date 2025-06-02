using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISharedTaskListRepository
    {
        Task<IEnumerable<SharedTaskList>> GetByTaskListIdAsync(Guid taskListId);
        Task<SharedTaskList?> GetByTaskListIdAndUserIdAsync(Guid userId, Guid taskListId);
        Task AddAsync(SharedTaskList shared);
        void Delete(SharedTaskList? sharedTaskList);
        void DeleteRange(IEnumerable<SharedTaskList> sharedTaskLists);
    }
}
