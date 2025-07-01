using TaskManager.Api.Models;

namespace TaskManager.Api.Data;

public class InMemoryTodoTaskRepository :  ITodoTaskRepository
{
	private readonly List<TodoTask> _tasks = [];
	private int _nextId = 1;

	public IEnumerable<TodoTask> GetAll() => _tasks;

	public TodoTask? GetById(int id) => _tasks.FirstOrDefault(i => i.Id == id);

	public void Add(TodoTask task)
	{
		task.Id = _nextId++;
		_tasks.Add(task);
	}

	public void Update(TodoTask task)
	{
		var index = _tasks.FindIndex(t => t.Id == task.Id);
		if (index != -1)
			_tasks[index] = task;
	}

	public void Delete(int id)
	{
		var foundTask = GetById(id);
		if (foundTask != null)
			_tasks.Remove(foundTask);
	}
}