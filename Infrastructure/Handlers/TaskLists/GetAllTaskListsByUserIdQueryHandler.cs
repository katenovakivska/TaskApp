using Application.Queries.TaskLists;
using Domain.DTO;
using Domain.Interfaces;

namespace Infrastructure.Handlers.TaskLists
{
    public class GetAllTaskListsByUserIdQueryHandler: IGetAllTaskListsByUserIdQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTaskListsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaskListDto>> HandleAsync(GetAllTaskListsByUserIdQuery query)
        {
            return await _unitOfWork.TaskLists.GetAllByUserIdAsync(query.UserId, query.PageNumber, query.PageSize);
        }
    }
}
