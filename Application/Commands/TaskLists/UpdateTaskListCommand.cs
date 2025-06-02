using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TaskLists
{
    public class UpdateTaskListCommand
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "The name must be between 1 and 255 characters long.")]
        public string Name { get; set; } = string.Empty;
    }
}
