using Application.Commands.SharedTaskLists;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Handlers.SharedTaskLists
{
    public class CreateSharedTaskListCommandHandler: ICommandHandler<CreateSharedTaskListCommand, (SharedTaskList? access, bool isListFound, bool isAccessCreated)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSharedTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(SharedTaskList? access, bool isListFound, bool isAccessCreated)> Handle(CreateSharedTaskListCommand command)
        {
            var taskList = await _unitOfWork.TaskLists.GetByListIdAndUserIdAsync(command.UserId, command.ListId);

            if (taskList == null)
                return (null, false, false);

            var existingAccess = await _unitOfWork.SharedTaskLists.GetByTaskListIdAndUserIdAsync(command.SharedUserId, command.ListId);

            if (existingAccess != null)
                return (null, true, false);

            var access = new SharedTaskList()
            {
                Id = Guid.NewGuid(),
                SharedWithUserId = command.SharedUserId,
                TaskListId = command.ListId
            };
            await _unitOfWork.SharedTaskLists.AddAsync(access);
            await _unitOfWork.SaveChangesAsync();

            return (access, true, true);
        }
    }
}
