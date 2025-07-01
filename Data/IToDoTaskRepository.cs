using TaskManager.Api.Models;

namespace TaskManager.Api.Data;

public interface ITodoTaskRepository
{
	IEnumerable<TodoTask> GetAll();
	TodoTask? GetById(int id);
	void Add(TodoTask task);
	void Update(TodoTask task);
	void Delete(int id);
}
