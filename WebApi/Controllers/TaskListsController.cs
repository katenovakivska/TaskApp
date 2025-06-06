﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Application.Commands.TaskLists;
using Application.Queries.TaskLists;
using AutoMapper;
using WebApi.Requests;
using Domain.DTO;
using Application.Common.Dispatchers;
using Domain.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskListsController : Controller
    {
        private readonly IDispatcher _dispatcher;
        private readonly IMapper _mapper;

        public TaskListsController(IDispatcher dispatcher,
                                   IMapper mapper)
        {
            _dispatcher = dispatcher;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "List created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Uncorrect name")]
        public async Task<IActionResult> CreateList([FromQuery] Guid userId, [FromBody] CreateTaskListRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateTaskListCommand command = _mapper.Map<CreateTaskListCommand>(request);
            command.OwnerId = userId;
            var taskList = await _dispatcher.Send<CreateTaskListCommand, TaskList?>(command); ;
            return Ok(taskList);
        }

        [HttpGet("{listId}")]
        public async Task<IActionResult> GetListByListId(Guid listId, [FromQuery] Guid userId)
        {
            var taskList = await _dispatcher.Query<GetTaskListByIdAndUserIdQuery, TaskList?>(new GetTaskListByIdAndUserIdQuery() 
            { 
                UserId = userId,
                ListId = listId
            });

            if (taskList == null) 
                return NotFound();

            return Ok(taskList);
        }

        [HttpDelete("{listId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTaskList(Guid listId, [FromQuery] Guid userId)
        {
            var isDeleted = await _dispatcher.Send<DeleteTaskListCommand, bool>(new DeleteTaskListCommand()
            {
                UserId = userId,
                ListId = listId
            });

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{listId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTaskList(Guid listId, [FromQuery] Guid userId, [FromBody] UpdateTaskListRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isUpdated = await _dispatcher.Send<UpdateTaskListCommand, bool>(new UpdateTaskListCommand()
            {
                UserId = userId,
                ListId = listId,
                Name = request.Name
            });

            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TaskListDto>>> GetTaskLists([FromQuery] Guid userId, [FromQuery] GetAllTaskListsRequest request)
        {
            var query = _mapper.Map<GetAllTaskListsByUserIdWithPaginationQuery>(request);
            query.UserId = userId;
            
            var taskLists = await _dispatcher.Query<GetAllTaskListsByUserIdWithPaginationQuery, IEnumerable<TaskListDto>>(query);

            if (!taskLists.Any())
                return NotFound();

            return Ok(taskLists);
        }
    }
}
