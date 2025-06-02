using Application.Commands.TaskLists;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Handlers.TaskLists
{
    public class CreateTaskListCommandHandler: ICreateTaskListCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskList?> HandleAsync(CreateTaskListCommand command)
        {
            var taskList = new TaskList
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                CreatedDate = DateTime.UtcNow,
                OwnerId = command.OwnerId,
            };
            List<TaskItem> taskItems = new List<TaskItem>();
            foreach (var taskItem in command.Tasks)
            {
                taskItems.Add(new TaskItem()
                {
                    Id = Guid.NewGuid(),
                    TaskListId = taskList.Id,
                    Title = taskItem.Title,
                    Description = taskItem.Description
                });
            }

            await _unitOfWork.TaskLists.AddAsync(taskList);
            await _unitOfWork.TaskItems.AddAsync(taskItems);
            await _unitOfWork.SaveChangesAsync();

            return taskList;
        }
    }
}
