using System.Globalization;
using Microsoft.AspNetCore.Mvc;
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
	public ActionResult Add(string description, string dueDate, string title, string priority)
	{
		if (!DateTime.TryParse(
			dueDate, 
			new DateTimeFormatInfo() { FullDateTimePattern = "yyyy-MM-dd" },
			out var dueDateParsed) || string.IsNullOrWhiteSpace(title))
			return BadRequest();
		
		repository.Add((new TodoTask()
		{
			Description = description,
			DueDate = dueDateParsed,
			Priority = priority,
			Title = title
		}));
		
		return Ok();
	}
}