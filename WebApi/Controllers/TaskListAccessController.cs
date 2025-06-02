using Application.Commands.SharedTaskLists;
using Application.Queries.SharedTaskLists;
using Application.Queries.TaskLists;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/tasklists/{listId}/access")]
    public class TaskListAccessController : Controller
    {
        private readonly IGetTaskListByIdAndUserIdQueryHandler _getTaskListByIdAndUserIdQueryHandler;
        private readonly ICreateSharedTaskListCommandHandler _createSharedTaskListCommandHandler;
        private readonly IGetAllAccessByTaskListIdQueryHandler _getAllAccessByTaskListIdQueryHandler;
        private readonly IDeleteSharedTaskListCommandHandler _deleteSharedTaskListCommandHandler;

        public TaskListAccessController(IGetTaskListByIdAndUserIdQueryHandler getTaskListByIdAndUserIdQueryHandler,
            ICreateSharedTaskListCommandHandler createSharedTaskListCommandHandler,
            IGetAllAccessByTaskListIdQueryHandler getAllAccessByTaskListIdQueryHandler,
            IDeleteSharedTaskListCommandHandler deleteSharedTaskListCommandHandler)
        {
            _getTaskListByIdAndUserIdQueryHandler = getTaskListByIdAndUserIdQueryHandler;
            _createSharedTaskListCommandHandler = createSharedTaskListCommandHandler;
            _getAllAccessByTaskListIdQueryHandler = getAllAccessByTaskListIdQueryHandler;
            _deleteSharedTaskListCommandHandler = deleteSharedTaskListCommandHandler;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> ShareListWithUser(Guid listId, [FromQuery] Guid userId, [FromBody] Guid sharedUserId)
        {
            var taskList = await _getTaskListByIdAndUserIdQueryHandler.HandleAsync(new GetTaskListByIdAndUserIdQuery()
            {
                UserId = userId,
                ListId = listId
            });

            if (taskList == null)
                return NotFound();
            else
            {
                var access = await _createSharedTaskListCommandHandler.HandleAsync(new CreateSharedTaskListCommand()
                {
                    UserId = sharedUserId,
                    ListId = listId
                });

                if (access == null) 
                    return Conflict();
                else
                    return Ok(access);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccessListByListId(Guid listId, [FromQuery] Guid userId)
        {
            var taskList = await _getTaskListByIdAndUserIdQueryHandler.HandleAsync(new GetTaskListByIdAndUserIdQuery()
            {
                UserId = userId,
                ListId = listId
            });
            if (taskList == null)
                return NotFound();
            else
            {
                var access = await _getAllAccessByTaskListIdQueryHandler.HandleAsync(listId);
                return Ok(access);
            }
        }

        [HttpDelete("{sharedUserId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveAccessByUserId(Guid listId, Guid sharedUserId, [FromQuery] Guid userId)
        {
            var isDeleted = await _deleteSharedTaskListCommandHandler.HandleAsync(new DeleteSharedTaskListCommand()
            {
                SharedUserId = sharedUserId,
                OwnerId = userId,
                ListId = listId
            });

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
