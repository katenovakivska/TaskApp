using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Queries.TaskLists
{
    public class GetTaskListByIdAndUserIdQuery: IQuery<TaskList?>
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
