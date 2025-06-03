using Domain.Entities;

namespace Application.Queries.SharedTaskLists
{
    public interface IGetAllAccessByTaskListIdQueryHandler
    {
        Task<(IEnumerable<SharedTaskList>?, bool isListFound)> HandleAsync(GetAllAccessByTaskListIdQuery query);
    }
}
