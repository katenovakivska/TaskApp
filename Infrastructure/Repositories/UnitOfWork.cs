using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{   
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ITaskListRepository TaskLists { get; }
        public ITaskItemRepository TaskItems { get; }
        public ISharedTaskListRepository SharedTaskLists { get; }

        public UnitOfWork(AppDbContext context,
                          ITaskListRepository taskLists,
                          ITaskItemRepository taskItems,
                          ISharedTaskListRepository sharedTaskLists)
        {
            _context = context;
            TaskLists = taskLists;
            TaskItems = taskItems;
            SharedTaskLists = sharedTaskLists;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
