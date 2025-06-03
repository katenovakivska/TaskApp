using Application.Commands.TaskLists;
using Application.Common.Interfaces;
using Domain.Interfaces;

namespace Infrastructure.Handlers.TaskLists
{
    public class UpdateTaskListCommandHandler: ICommandHandler<UpdateTaskListCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTaskListCommand command)
        {
            var taskList = await _unitOfWork.TaskLists.GetByListIdAndUserIdAsync(command.UserId, command.ListId);
            
            if (taskList == null)
            {
                return false;
            }
            
            taskList.Name = command.Name;
            _unitOfWork.TaskLists.Update(taskList);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
