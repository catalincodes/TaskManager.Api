using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.API.Models;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TodoTaskControllers(ITodoTaskRepository repository) : ControllerBase
{
	[HttpGet]
	public ActionResult<IEnumerable<TodoTask>> GetAll()
	{
		var tasks = repository.GetAll();
		return Ok(tasks);
	}

	[HttpPost]
	public ActionResult Add([FromBody] TaskDTO task)
	{
		if (!DateTime.TryParse(
			task.DueDate, 
			new DateTimeFormatInfo() { FullDateTimePattern = "yyyy-MM-dd" },
			out var dueDateParsed) || string.IsNullOrWhiteSpace(task.Title))
			return BadRequest();
		
		repository.Add((new TodoTask()
		{
			Description = task.Description,
			DueDate = dueDateParsed,
			Priority = task.Priority,
			Title = task.Title
		}));
		
		return Ok();
	}

	[HttpPut]
	public ActionResult Update(int id, string? description, string? dueDate, string? priority, string? status)
	{
		var task = repository.GetById(id);
		if (task is null)
			return BadRequest();
		
		if (description is not null && task.Description != description)
			task.Description = description;
		
		if (priority is not null && task.Priority != priority)
			task.Priority = priority;
		
		if (dueDate is not null && !DateTime.TryParse(
			    dueDate, 
			    new DateTimeFormatInfo() { FullDateTimePattern = "yyyy-MM-dd" },
			    out var dueDateParsed) && task.DueDate != dueDateParsed)
			task.DueDate = dueDateParsed;
		
		if (status is not null && task.Status != status)
			task.Status = status;

		repository.Update(task);
		
		return Ok();
	}

	[HttpDelete]
	public ActionResult Delete(int id)
	{
		var task = repository.GetById(id);
		if (task is null)
			return BadRequest();
		
		repository.Delete(id);
		return Ok();
	}
}