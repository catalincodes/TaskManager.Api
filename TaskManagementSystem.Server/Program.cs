using TaskManagementSystem.Server.Data;
using TaskManagementSystem.Server.Models;

const string corsPolicyName = "AllowAll";
const string frontEndUrl = "http://localhost:5118";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins(frontEndUrl);
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IToDoTaskRepository, InMemoryToDoTaskRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Seed dummy data (optional)
var repo = app.Services.GetRequiredService<IToDoTaskRepository>();
repo.Add(new ToDoTask
{
    Title = "Buy groceries",
    Description = "Milk, Bread, Eggs",
    DueDate = DateTime.Today.AddDays(2),
    Status = "ToDo",
    Priority = "High"
});
repo.Add(new ToDoTask
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

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
