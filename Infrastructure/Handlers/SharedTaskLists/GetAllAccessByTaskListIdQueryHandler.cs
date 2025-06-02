using Application.Queries.SharedTaskLists;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Handlers.SharedTaskLists
{
    public class GetAllAccessByTaskListIdQueryHandler: IGetAllAccessByTaskListIdQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAccessByTaskListIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SharedTaskList>> HandleAsync(Guid listId)
        {
            return await _unitOfWork.SharedTaskLists.GetByTaskListIdAsync(listId);
        }
    }
}
