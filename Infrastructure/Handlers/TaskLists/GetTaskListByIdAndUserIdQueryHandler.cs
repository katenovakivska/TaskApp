using Application.Common.Interfaces;
using Application.Queries.TaskLists;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Handlers.TaskLists
{
    public class GetTaskListByIdAndUserIdQueryHandler: IQueryHandler<GetTaskListByIdAndUserIdQuery, TaskList?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTaskListByIdAndUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskList?> Handle(GetTaskListByIdAndUserIdQuery query)
        {
            return await _unitOfWork.TaskLists.GetByListIdAndUserIdAsync(query.UserId, query.ListId);
        }
    }
}
