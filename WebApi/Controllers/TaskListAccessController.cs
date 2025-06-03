using Application.Commands.SharedTaskLists;
using Application.Queries.SharedTaskLists;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/tasklists/{listId}/access")]
    public class TaskListAccessController : Controller
    {
        private readonly ICreateSharedTaskListCommandHandler _createSharedTaskListCommandHandler;
        private readonly IGetAllAccessByTaskListIdQueryHandler _getAllAccessByTaskListIdQueryHandler;
        private readonly IDeleteSharedTaskListCommandHandler _deleteSharedTaskListCommandHandler;

        public TaskListAccessController(ICreateSharedTaskListCommandHandler createSharedTaskListCommandHandler,
            IGetAllAccessByTaskListIdQueryHandler getAllAccessByTaskListIdQueryHandler,
            IDeleteSharedTaskListCommandHandler deleteSharedTaskListCommandHandler)
        {
            _createSharedTaskListCommandHandler = createSharedTaskListCommandHandler;
            _getAllAccessByTaskListIdQueryHandler = getAllAccessByTaskListIdQueryHandler;
            _deleteSharedTaskListCommandHandler = deleteSharedTaskListCommandHandler;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> ShareListWithUser(Guid listId, [FromQuery] Guid userId, [FromBody] Guid sharedUserId)
        {
            (var access, var isListFound, var isAccessCreated) = await _createSharedTaskListCommandHandler.HandleAsync(new CreateSharedTaskListCommand()
            {
                UserId = userId,
                ListId = listId,
                SharedUserId = sharedUserId
            });

            if (!isListFound)
                return NotFound();
            else
            {
                if (!isAccessCreated) 
                    return Conflict();
                else
                    return Ok(access);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccessListByListId(Guid listId, [FromQuery] Guid userId)
        {
            (var access, var isListFound) = await _getAllAccessByTaskListIdQueryHandler.HandleAsync(new GetAllAccessByTaskListIdQuery()
            { 
                UserId = userId,
                ListId = listId
            });

            if (!isListFound)
                return NotFound();
            else
                return Ok(access);
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
