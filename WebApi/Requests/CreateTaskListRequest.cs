using Application.Commands.TaskLists;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Requests
{
    public class CreateTaskListRequest
    {
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "The name must be between 1 and 255 characters long.")]
        public string Name { get; set; } = string.Empty;
        public List<CreateTaskItemCommand> Tasks { get; set; } = new();
    }
}
