using Application.Commands.SharedTaskLists;
using Application.Common.Interfaces;
using Domain.Interfaces;

namespace Infrastructure.Handlers.SharedTaskLists
{
    public class DeleteSharedTaskListCommandHandler: ICommandHandler<DeleteSharedTaskListCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSharedTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteSharedTaskListCommand command)
        {
            var taskList = await _unitOfWork.TaskLists.GetByListIdAndUserIdAsync(command.OwnerId, command.ListId);

            if (taskList == null)
            {
                return false;
            }

            var access = await _unitOfWork.SharedTaskLists.GetByTaskListIdAndUserIdAsync(command.SharedUserId, command.ListId);
            
            if (access == null)
            {
                return false;
            }

            _unitOfWork.SharedTaskLists.Delete(access);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
