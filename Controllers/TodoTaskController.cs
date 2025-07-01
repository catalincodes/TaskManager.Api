using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTaskControllers: ControllerBase
{
	private readonly ITodoTaskRepository _repository;

	public TodoTaskControllers(ITodoTaskRepository repository) => 
		_repository = repository;

	[HttpGet]
	public ActionResult<IEnumerable<TodoTask>> GetAll()
	{
		var tasks = _repository.GetAll();
		return Ok(tasks);
	}
}