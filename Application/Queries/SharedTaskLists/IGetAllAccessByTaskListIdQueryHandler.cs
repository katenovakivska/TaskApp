using Domain.Entities;

namespace Application.Queries.SharedTaskLists
{
    public interface IGetAllAccessByTaskListIdQueryHandler
    {
        Task<IEnumerable<SharedTaskList>> HandleAsync(Guid listId);
    }
}
