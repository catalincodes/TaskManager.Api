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

	[HttpPut("{id}")]
	public ActionResult Update(int id, [FromBody] TaskDTO task)
	{
		var retrievedTask = repository.GetById(id);

		if (retrievedTask is null)
			return NoContent();
		
		if (!DateTime.TryParse(
			    task.DueDate,
			    new DateTimeFormatInfo() { FullDateTimePattern = "yyyy-MM-dd" },
			    out var dueDateParsed))
			return BadRequest();
		
		retrievedTask.Title = task.Title;
		retrievedTask.Description = task.Description;
		retrievedTask.DueDate = dueDateParsed;
		retrievedTask.Priority = task.Priority;

		repository.Update(retrievedTask);
		
		return Ok(retrievedTask);
	}

	[HttpDelete("{id}")]
	public ActionResult Delete(int id)
	{
		var task = repository.GetById(id);
		if (task is null)
			return NotFound();
		
		repository.Delete(id);
		return Ok();
	}
}