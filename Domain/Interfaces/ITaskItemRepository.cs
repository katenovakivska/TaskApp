using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetByTaskListIdAsync(Guid taskListId);
        Task AddAsync(IEnumerable<TaskItem> tasks);
        void UpdateAsync(TaskItem task);
        void DeleteRange(IEnumerable<TaskItem> tasks);
        Task<TaskItem?> GetByTaskIdAsync(Guid taskId);
    }
}
