using Application.Commands.TaskLists;
using Application.Queries.TaskLists;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Handlers.TaskLists
{
    public class UpdateTaskListCommandHandler: IUpdateTaskListCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> HandleAsync(UpdateTaskListCommand command)
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
