using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskListRepository
    {
        Task<TaskList?> GetByListIdAndUserIdAsync(Guid userId, Guid listId);
        Task<TaskList?> GetByListIdAndOwnerIdAsync(Guid userId, Guid listId);
        Task<IEnumerable<TaskList>> GetAllAsync();
        Task AddAsync(TaskList taskList);
        void Update(TaskList taskList);
        void Delete(Guid listId, Guid userId);
    }
}
