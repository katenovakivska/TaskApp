using Application.Commands.TaskLists;
using Domain.Interfaces;

namespace Infrastructure.Handlers.TaskLists
{
    public class DeleteTaskListCommandHandler: IDeleteTaskListCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> HandleAsync(DeleteTaskListCommand command)
        {
            var taskList = await _unitOfWork.TaskLists.GetByListIdAndOwnerIdAsync(command.UserId, command.ListId);

            if (taskList == null)
            {
                return false;
            }

            var tasks = await _unitOfWork.TaskItems.GetByTaskListIdAsync(command.ListId);
            var access = await _unitOfWork.SharedTaskLists.GetByTaskListIdAsync(command.ListId);

            _unitOfWork.TaskItems.DeleteRange(tasks);
            _unitOfWork.SharedTaskLists.DeleteRange(access);
            _unitOfWork.TaskLists.Delete(command.ListId, command.UserId);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
