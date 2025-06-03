using Application.Common.Interfaces;
using Application.Queries.SharedTaskLists;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Handlers.SharedTaskLists
{
    public class GetAllAccessByTaskListIdQueryHandler: IQueryHandler<GetAllAccessByTaskListIdQuery, (IEnumerable<SharedTaskList>?, bool isListFound)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAccessByTaskListIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IEnumerable<SharedTaskList>?, bool isListFound)> Handle(GetAllAccessByTaskListIdQuery query)
        {
            var taskList = await _unitOfWork.TaskLists.GetByListIdAndUserIdAsync(query.UserId, query.ListId);

            if (taskList == null)
                return (null, false);

            return (await _unitOfWork.SharedTaskLists.GetByTaskListIdAsync(taskList.Id), true);
        }
    }
}
