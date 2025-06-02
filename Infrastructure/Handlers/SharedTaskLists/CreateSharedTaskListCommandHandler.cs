using Application.Commands.SharedTaskLists;
using Application.Queries.SharedTaskLists;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Handlers.SharedTaskLists
{
    public class CreateSharedTaskListCommandHandler: ICreateSharedTaskListCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSharedTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SharedTaskList?> HandleAsync(CreateSharedTaskListCommand command)
        {
            var existingAccess = await _unitOfWork.SharedTaskLists.GetByTaskListIdAndUserIdAsync(command.UserId, command.ListId);

            if (existingAccess != null)
            {
                return null;
            }

            var access = new SharedTaskList()
            {
                Id = Guid.NewGuid(),
                SharedWithUserId = command.UserId,
                TaskListId = command.ListId
            };
            await _unitOfWork.SharedTaskLists.AddAsync(access);
            await _unitOfWork.SaveChangesAsync();

            return access;
        }
    }
}
