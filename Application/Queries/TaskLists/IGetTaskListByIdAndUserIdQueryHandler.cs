using Domain.Entities;

namespace Application.Queries.TaskLists
{
    public interface IGetTaskListByIdAndUserIdQueryHandler
    {
        Task<TaskList?> HandleAsync(GetTaskListByIdAndUserIdQuery query);
    }
}
