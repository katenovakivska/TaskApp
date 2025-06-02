using Application.Commands.SharedTaskLists;
using Application.Queries.SharedTaskLists;
using Application.Queries.TaskLists;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Handlers.SharedTaskLists
{
    public class DeleteSharedTaskListCommandHandler: IDeleteSharedTaskListCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSharedTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> HandleAsync(DeleteSharedTaskListCommand command)
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
