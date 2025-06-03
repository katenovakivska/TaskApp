using Application.Common.Interfaces;
using Domain.DTO;

namespace Application.Queries.TaskLists
{
    public class GetAllTaskListsByUserIdWithPaginationQuery: IQuery<IEnumerable<TaskListDto>>
    {
        public Guid UserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
