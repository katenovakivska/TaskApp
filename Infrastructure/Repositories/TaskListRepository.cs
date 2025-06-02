using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly AppDbContext _context;

        public TaskListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskList>> GetAllAsync()
        {
            return await _context.TaskLists.ToListAsync();
        }

        public async Task<TaskList?> GetByListIdAndUserIdAsync(Guid userId, Guid listId)
        {
            return await _context.TaskLists.Include(t => t.Tasks).Include(t => t.SharedWithUsers)
                         .FirstOrDefaultAsync(t => t.Id == listId && 
                         (t.OwnerId == userId || 
                         t.SharedWithUsers.Any(s => s.SharedWithUserId == userId)));
        }

        public async Task<TaskList?> GetByListIdAndOwnerIdAsync(Guid userId, Guid listId)
        {
            return await _context.TaskLists.Include(t => t.Tasks).Include(t => t.SharedWithUsers)
                         .FirstOrDefaultAsync(t => t.Id == listId && t.OwnerId == userId);
        }

        public async Task AddAsync(TaskList list)
        {
            await _context.TaskLists.AddAsync(list);
        }

        public void Update(TaskList list)
        {
            _context.TaskLists.Update(list);
        }

        public void Delete(Guid listId, Guid userId)
        {
            var list = _context.TaskLists.FirstOrDefault(t => t.OwnerId == userId ||
                         t.SharedWithUsers.Any(s => s.SharedWithUserId == userId));
            if (list != null) 
                _context.TaskLists.Remove(list);
        }
    }
}
