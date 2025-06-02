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
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITaskListRepository, TaskListRepository>();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ISharedTaskListRepository, SharedTaskListRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICreateTaskListCommandHandler, CreateTaskListCommandHandler>();
builder.Services.AddScoped<IGetTaskListByIdAndUserIdQueryHandler, GetTaskListByIdAndUserIdQueryHandler>();
builder.Services.AddScoped<ICreateSharedTaskListCommandHandler, CreateSharedTaskListCommandHandler>();
builder.Services.AddScoped<IDeleteTaskListCommandHandler, DeleteTaskListCommandHandler>();
builder.Services.AddScoped<IUpdateTaskListCommandHandler, UpdateTaskListCommandHandler>();
builder.Services.AddScoped<IGetAllAccessByTaskListIdQueryHandler, GetAllAccessByTaskListIdQueryHandler>();

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
