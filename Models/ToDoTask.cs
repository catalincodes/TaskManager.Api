namespace TaskManager.Api.Models;

public class TodoTask
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string? Description { get; set; }
	public DateTime DueDate { get; set; }
	public string Status { get; set; } = "ToDo"; // ToDo, InProgress, Done
	public string Priority { get; set; } = "Medium"; // Low, Medium, High
}