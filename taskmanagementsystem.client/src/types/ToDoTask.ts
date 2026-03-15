export interface ToDoTask {
  id: number;
  title: string;
  description?: string;
  dueDate: Date;
  status: string;
  priority: string;
}
