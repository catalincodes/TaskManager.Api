using TaskManager.Api.Data;
using TaskManager.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoTaskRepository, InMemoryTodoTaskRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Seed dummy data (optional)
var repo = app.Services.GetRequiredService<ITodoTaskRepository>();
repo.Add(new TodoTask
{
	Title = "Buy groceries",
	Description = "Milk, Bread, Eggs",
	DueDate = DateTime.Today.AddDays(2),
	Status = "ToDo",
	Priority = "High"
});
repo.Add(new TodoTask
{
	Title = "Finish API project",
	DueDate = DateTime.Today.AddDays(5),
	Status = "InProgress",
	Priority = "Medium"
});

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
