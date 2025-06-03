using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class TaskItemRepository: ITaskItemRepository
    {
        private readonly AppDbContext _context;

        public TaskItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetByTaskListIdAsync(Guid taskListId)
        {
            return await _context.TaskItems.Where(t => t.TaskListId == taskListId).ToListAsync();
        }

        public async Task AddAsync(IEnumerable<TaskItem> taskItems)
        {
            await _context.TaskItems.AddRangeAsync(taskItems);
        }

        public void UpdateAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
        }

        public void DeleteRange(IEnumerable<TaskItem> taskItems)
        {
            if (taskItems.Count() > 0)
                _context.TaskItems.RemoveRange(taskItems);
        }
    }
}
