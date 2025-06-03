using Application.Common.Interfaces;
using Application.Queries.TaskLists;
using Domain.DTO;
using Domain.Interfaces;

namespace Infrastructure.Handlers.TaskLists
{
    public class GetAllTaskListsByUserIdWithPaginationQueryHandler: IQueryHandler<GetAllTaskListsByUserIdWithPaginationQuery, IEnumerable<TaskListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTaskListsByUserIdWithPaginationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaskListDto>> Handle(GetAllTaskListsByUserIdWithPaginationQuery query)
        {
            return await _unitOfWork.TaskLists.GetAllByUserIdAsync(query.UserId, query.PageNumber, query.PageSize);
        }
    }
}
