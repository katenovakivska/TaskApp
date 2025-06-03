using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Queries.SharedTaskLists
{
    public class GetAllAccessByTaskListIdQuery: IQuery<(IEnumerable<SharedTaskList>?, bool isListFound)>
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
