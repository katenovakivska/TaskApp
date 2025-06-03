using Domain.DTO;

namespace Application.Queries.TaskLists
{
    public interface IGetAllTaskListsByUserIdQueryHandler
    {
        Task<IEnumerable<TaskListDto>> HandleAsync(GetAllTaskListsByUserIdQuery query);
    }
}
