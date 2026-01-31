using System.Xml.Linq;
using TaskManagementSystem.Server.Models;

namespace TaskManagementSystem.Server.Data;

public class InMemoryToDoTaskRepository : IToDoTaskRepository
{
    private readonly List<ToDoTask> _tasks = [];
    private int _nextId = 1;

    public IEnumerable<ToDoTask> GetAll() => _tasks;

    public ToDoTask? GetById(int id) => _tasks.FirstOrDefault(i => i.Id == id);

    public void Add(ToDoTask task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
    }

    public void Update(ToDoTask task)
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
