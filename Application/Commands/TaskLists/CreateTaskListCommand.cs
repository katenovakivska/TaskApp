using Application.Common.Interfaces;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TaskLists
{
    public class CreateTaskListCommand: ICommand<TaskList?>
    {
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "The name must be between 1 and 255 characters long.")]
        public string Name { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public List<CreateTaskItemCommand> Tasks { get; set; } = new();
    }
}
