using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Application.Commands.TaskLists;
using Application.Queries.TaskLists;
using Application.Commands.SharedTaskLists;
using Application.Queries.SharedTaskLists;
using Infrastructure.Handlers.SharedTaskLists;
using Infrastructure.Handlers.TaskLists;
using Application.Common.Dispatchers;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITaskListRepository, TaskListRepository>();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ISharedTaskListRepository, SharedTaskListRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDispatcher, Dispatcher>();
builder.Services.AddScoped<ICommandHandler<CreateTaskListCommand, TaskList?>, CreateTaskListCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateTaskListCommand, bool>, UpdateTaskListCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteTaskListCommand, bool>, DeleteTaskListCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllTaskListsByUserIdWithPaginationQuery, IEnumerable<TaskListDto>>, GetAllTaskListsByUserIdWithPaginationQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetTaskListByIdAndUserIdQuery, TaskList?>, GetTaskListByIdAndUserIdQueryHandler>();
builder.Services.AddScoped<ICommandHandler<CreateSharedTaskListCommand, (SharedTaskList? access, bool isListFound, bool isAccessCreated)>, CreateSharedTaskListCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllAccessByTaskListIdQuery, (IEnumerable<SharedTaskList>?, bool isListFound)>, GetAllAccessByTaskListIdQueryHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteSharedTaskListCommand, bool>, DeleteSharedTaskListCommandHandler>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=taskmanager.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
