using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class SharedTaskListRepository: ISharedTaskListRepository
    {
        private readonly AppDbContext _context;

        public SharedTaskListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SharedTaskList>> GetByTaskListIdAsync(Guid taskListId)
        {
            return await _context.SharedTaskLists.Where(s => s.TaskListId == taskListId).ToListAsync();
        }

        public async Task<SharedTaskList?> GetByTaskListIdAndUserIdAsync(Guid userId, Guid taskListId)
        {
            return await _context.SharedTaskLists.FirstOrDefaultAsync(s => s.SharedWithUserId == userId && s.TaskListId == taskListId);
        }

        public async Task AddAsync(SharedTaskList sharedTaskList)
        {
            await _context.SharedTaskLists.AddAsync(sharedTaskList);
        }

        public void Delete(SharedTaskList? sharedTaskList)
        {
            if (sharedTaskList != null)
                _context.SharedTaskLists.Remove(sharedTaskList);
        }

        public void DeleteRange(IEnumerable<SharedTaskList> sharedTaskLists)
        {
            if (sharedTaskLists != null)
                _context.SharedTaskLists.RemoveRange(sharedTaskLists);
        }
    }
}
